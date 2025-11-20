# CleanContacts - Backend

##  Descrição

CleanContacts é um backend desenvolvido em **.NET 10** utilizando
**Clean Architecture**, **CQRS**, **JWT**, **Mapster**, **RabbitMQ** e
**EF Core**.\
A aplicação fornece um CRUD de contatos vinculados a um usuário
autenticado.\
Após a criação de um contato, um evento é publicado em RabbitMQ para
geração de auditorias.# clean-contacts
