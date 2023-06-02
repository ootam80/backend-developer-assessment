
CREATE LOGIN DevtestLogin WITH PASSWORD = 'PassW0rd1!1234'

CREATE USER Devtest FOR LOGIN DevtestLogin

USE MusicBrainz
GO
ALTER ROLE [db_owner] ADD MEMBER Devtest
GO