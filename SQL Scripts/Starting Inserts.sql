use dbPortalWebApps

select * from SystemSettings
select * from SystemSettingsHistory
select * from Users
select * from Applications

insert into SystemSettings values ('SMTP Server','Servidor de SMTP responsável pelo envio de e-mails de aplicação','smtp.office365.com',0)
insert into SystemSettings values ('SMTP Port','Porta de SMTP responsável pelo envio de e-mails de aplicação','587',0)
insert into SystemSettings values ('SMTP SSL','SSL de segurança de SMTP responsável pelo envio de e-mails de aplicação','True',1)
insert into SystemSettings values ('SMTP Mail','E-mail de SMTP responsável pelo envio de e-mails de aplicação','',0)
insert into SystemSettings values ('SMTP Password','Senha de SMTP responsável pelo envio de e-mails de aplicação','',0)
insert into SystemSettings values ('Application Uri','Uri base da aplicação responsável pelos redirecionamentos ao longo do processo.','https://localhost:7248/',0)

insert into Users values('Igor Henrique Salvador', 'igorsalvador0621@gmail.com','398.642.978-64','2002-06-21', 1, '', GETDATE(), null, 1)

