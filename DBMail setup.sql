USE msdb;

--configure server to turn mail on
sp_configure 'show advanced options', 1;
go
reconfigure;
go
sp_configure 'Database Mail XPs', 1;
go
reconfigure;
go

--create sysmail account
IF NOT EXISTS(SELECT * FROM msdb.dbo.sysmail_account
	WHERE name = 'SQLServer Express')
	BEGIN
		EXECUTE msdb.dbo.sysmail_add_account_sp
		@account_name = 'SQLServer Express',
		@email_address = 'leadensky@hotmail.com',
		@display_name = 'SQL Server Database Mail',
		@replyto_address = 'leadensky@hotmail.com',
		@description = '',
		@mailserver_name = 'smtp-mail.outlook.com',
		@mailserver_type = 'SMTP',
		@port = 587,
		@username = 'leadensky@hotmail.com',
		@password = 'PASSWORD GOES HERE',
		@use_default_credentials = 0,
		@enable_ssl = 1;
	END

--edit sysmail account (if necessary)
EXECUTE msdb.dbo.sysmail_update_account_sp
	@account_id = 1,
	@mailserver_name = 'smtp-mail.outlook.com',
	@port = 587,
	@enable_ssl = 1,
	@no_credential_change = 1

--create mail profile
IF NOT EXISTS (SELECT * FROM msdb.dbo.sysmail_profile
	WHERE name = 'SQLServer Express Edition')
	BEGIN
		EXECUTE msdb.dbo.sysmail_add_profile_sp
		@profile_name = 'SQLServer Express Edition',
		@description = 'DBMail account used by SQL Server Express';
	END

--link mail account with profile
IF NOT EXISTS (SELECT * FROM msdb.dbo.sysmail_profileaccount pa
	INNER JOIN msdb.dbo.sysmail_profile p ON pa.profile_id = p.profile_id
	INNER JOIN msdb.dbo.sysmail_account a on pa.account_id = a.account_id
	WHERE p.name = 'SQLServer Express Edition' AND a.name = 'SQLServer Express')
	BEGIN
		EXECUTE msdb.dbo.sysmail_add_profileaccount_sp
		@profile_name = 'SQLServer Express Edition',
		@account_name = 'SQLServer Express',
		@sequence_number = 1;
	END

--send a test message
EXEC msdb.dbo.sp_send_dbmail
	@profile_name = 'SQLServer Express Edition',
	@recipients = '8019165518@tmomail.net',
	@body = 'Test from the database',
	@subject = 'You have a reminder!';