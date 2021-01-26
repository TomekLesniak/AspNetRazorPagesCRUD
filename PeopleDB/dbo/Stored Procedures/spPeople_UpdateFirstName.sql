CREATE PROCEDURE [dbo].[spPeople_UpdateFirstName]
	@Id int,
	@Firstname nvarchar(50)
AS
begin
	update dbo.People
	set FirstName = @Firstname
	where Id = @Id;

end