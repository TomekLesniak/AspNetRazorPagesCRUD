CREATE PROCEDURE [dbo].[spPeople_Create]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateOfBirth datetime2(7),
	@IsActive bit,
	@Id int output
AS
begin
	
	insert into dbo.People(FirstName, LastName, DateOfBirth, IsActive)
	values (@FirstName, @LastName, @DateOfBirth, @IsActive);

	set @Id = SCOPE_IDENTITY();
end
	