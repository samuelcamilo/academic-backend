using System;
using System.Collections.Generic;
using Uni.Academic.Data.Repositories;
using SimpleInjector;
using Uni.Academic.Core.Interfaces.Repositories;
using System.Reflection;
using Uni.Academic.Core.RequestHandlers.Pipelines;
using MediatR;
using MediatR.Pipeline;
using System.Linq;
using FluentValidation;
using Uni.Academic.Core.Models;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Uni.Academic.IoC
{
    public static class SimpleInjectorBootstrap
    {
        private static readonly Type _repositoryType = typeof(Repository<>);
        private static readonly Type _entityType = typeof(Entity);

        public static void Initialize(Container container)
        {
            ConfigureDefaultImplementations(container);
            ConfigureValidators(container);
            ConfigureMediatR(container);
        }

        private static void ConfigureDefaultImplementations(Container container)
        {
            var assembliesToScan = _repositoryType.GetTypeInfo().Assembly;
            var typesToRegister = assembliesToScan.ExportedTypes.Select(t => t.GetTypeInfo());

            var registrations = from type in typesToRegister
                                let @interface = type.ImplementedInterfaces.FirstOrDefault(inter => inter.Name == $"I{type.Name}")
                                where @interface != null && type.IsClass && !type.IsGenericType
                                select (@interface, type.AsType());

            foreach (var (@interface, @class) in registrations)
                container.Register(@interface, @class, Lifestyle.Scoped);
        }

        private static void ConfigureValidators(Container container)
        {
            var baseType = typeof(AbstractValidator<>);
            var validatorTypes = _entityType.Assembly.ExportedTypes
                .Where(t => t.IsClass && !t.IsAbstract && t.BaseType.IsGenericType && (t.BaseType.GetGenericTypeDefinition() == baseType || t.BaseType?.BaseType?.GetGenericTypeDefinition() == baseType))
                .ToArray();

            foreach (var type in validatorTypes)
                container.Register(type.BaseType, type, Lifestyle.Scoped);
        }

        private static void ConfigureMediatR(Container container)
        {
            var assemblies = GetAssemblies().ToArray();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);

            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var notificationHandlerTypes = container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
            container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);

            // Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),

                // The order does matter, dont change the ExceptionPipelineBehavior and ValidationPipelineBehavior positions
                typeof(ExceptionPipelineBehavior<,>),
                typeof(ValidationPipelineBehavior<,>),
            });
            container.Collection.Register(typeof(IRequestPreProcessor<>));
            container.Collection.Register(typeof(IRequestPostProcessor<,>));

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return _repositoryType.GetTypeInfo().Assembly;
            yield return typeof(ExceptionPipelineBehavior<,>).GetTypeInfo().Assembly;
        }
    }
}
