# QAcademic Backend

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

O sistema funciona como um portal para alunos, professores e administradores de uma determinada instituição de ensino
superior. O projeto tem como base se aprofundar em várias tecnologias que compoem uma boa arquitetura de software.

# Tecnologias
Diversas tecnologias são usadas no projeto. Abaixo, encontra-se as principais tecnologias utilizadas.

  * [.NET Core]() - .NET Core 3.1
  * [Entity Framework]() - Entity Framework 4.1
  * [Simple Injector]() - Simple Injector
  * [XUnit]() - XUnit
  * [AutoMapper]() - AutoMapper
  * [MediatR]() - MediatR
  * [RabbitMQ]() - Message Broker
  * [Vue.JS]() - Vue.JS

# Features
O sistema será bem dinâmico e intuitivo. A ideia é realmente aprender um pouco sobre esse conjunto de tecnologias.
Podemos dividir as features por personas no sistema.

 - Administrador

O administrador tem o dominio total do sistema. Ele é responsável por realizar o CRUD completo dos alunos e professores, como também, outros usuários administradores. Ele também é responsável pela criação de disciplinas e cursos da instituição de ensino.
Um curso poderá ter diversas disciplinas, como também, diversos alunos. Lembrando que deverá existir turmas
dos cursos criados. (manhã, tarde e noite)

- Professor

Já os professores poderão abrir a aula para inicio da chamada, anexar documentos para os alunos baixarem, ver as disciplinas e cursos aqual estão ministrando as aulas.

- Alunos

Os alunos poderão ver as disciplinas disponíveis, editar seu perfil, verificar os boletos disponíveis para pagamento, materiais de aula e notas.

### Instalação
TODO