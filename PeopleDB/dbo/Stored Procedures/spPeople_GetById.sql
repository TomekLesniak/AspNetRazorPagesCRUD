CREATE PROCEDURE [dbo].[spPeople_GetById]
	@Id int
AS
begin
	select [Id], [FirstName], [LastName], [DateOfBirth], [IsActive]
	from dbo.People
	where Id = @Id;
end
