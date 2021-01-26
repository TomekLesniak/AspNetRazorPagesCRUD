CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
begin
	select [Id], [FirstName], [LastName], [DateOfBirth], [IsActive]
	from dbo.People
end
