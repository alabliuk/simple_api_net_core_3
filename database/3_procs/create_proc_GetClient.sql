-- =============================================
-- Author:		Andre Leme
-- Create date: 27 10 2020
-- Description:	Get apenas um cliente
-- =============================================
CREATE PROCEDURE GetClient
	@id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Client WHERE Id = @id
END
GO
