use dbPortalWebApps

select * from SystemSettings
select * from SystemSettingsHistory
select * from Users
select * from Applications

insert into SystemSettings values ('SMTP Server','Servidor de SMTP respons�vel pelo envio de e-mails de aplica��o','smtp.office365.com',0)
insert into SystemSettings values ('SMTP Port','Porta de SMTP respons�vel pelo envio de e-mails de aplica��o','587',0)
insert into SystemSettings values ('SMTP SSL','SSL de seguran�a de SMTP respons�vel pelo envio de e-mails de aplica��o','True',1)
insert into SystemSettings values ('SMTP Mail','E-mail de SMTP respons�vel pelo envio de e-mails de aplica��o','',0)
insert into SystemSettings values ('SMTP Password','Senha de SMTP respons�vel pelo envio de e-mails de aplica��o','',0)
insert into SystemSettings values ('Application Uri','Uri base da aplica��o respons�vel pelos redirecionamentos ao longo do processo.','https://localhost:7248/',0)

insert into Users values('Igor Henrique Salvador', 'igorsalvador0621@gmail.com','398.642.978-64','2002-06-21', 1, '', GETDATE(), null, 1)

