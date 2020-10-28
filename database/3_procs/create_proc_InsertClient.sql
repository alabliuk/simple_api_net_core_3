-- =============================================
-- Author:		Andre Leme
-- Create date: 27 10 2020
-- Description:	Insert Client
-- =============================================
CREATE PROCEDURE InsertClient
	@name VARCHAR(200)
	,@phone INT
	,@email VARCHAR(50)
	,@comments VARCHAR(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Client (
		[name]
		,phone
		,email
		,comments
		,lastUpdate
	) VALUES (
		@name
		,@phone
		,@email
		,@comments
		,GETDATE()
	)

	SELECT @@ROWCOUNT
		
END
GO
