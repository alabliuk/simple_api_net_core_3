-- =============================================
-- Author:		Andre Leme
-- Create date: 27 10 2020
-- Description:	Update Client
-- =============================================
CREATE PROCEDURE UpdateClient
	@id INT
	,@name VARCHAR(200)
	,@phone INT
	,@email VARCHAR(50)
	,@comments VARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
		Client SET
			[name] = @name
			,phone = @phone
			,email = @email
			,comments = @comments
			,lastUpdate = GETDATE()
	WHERE
		Id = @id

	SELECT @@ROWCOUNT
		
END
GO