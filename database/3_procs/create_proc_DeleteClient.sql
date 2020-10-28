-- =============================================
-- Author:		Andre Leme
-- Create date: 27 10 2020
-- Description:	Delete Client
-- =============================================
CREATE PROCEDURE DeleteClient
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Client WHERE id = @id

	SELECT @@ROWCOUNT
END
GO