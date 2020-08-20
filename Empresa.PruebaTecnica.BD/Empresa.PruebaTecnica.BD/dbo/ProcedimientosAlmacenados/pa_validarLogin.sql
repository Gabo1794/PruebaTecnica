CREATE PROCEDURE pa_validarLogin 
	@usuario varchar(20),
	@contrasena varchar(max)
AS
BEGIN
	SELECT 
		IIF(COUNT(*) > 0, 'true', 'false') AS 'Login'
	FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena
END
GO