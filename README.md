# CsharpWebAPI\

## Connect to the database using AddDbContext to add services to the container
```cs
// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer("Server=stellasqldbdemo.database.windows.net;Database=SchoolDB;Trusted_Connection=False;Encrypt=True;");
});
```
## Commands I used in Package Management Console
add-migration InitialCreate
update-database

## SQL queries 
Create Department table
```sql
CREATE TABLE dbo.Department(
DepartmentId int NOT NULL IDENTITY(1,1),
DepartmentName nvarchar(500),
PRIMARY KEY(DepartmentId)
);

insert into dbo.Department(DepartmentName) values('IT');
insert into dbo.Department(DepartmentName) values('Support');


select * from dbo.Department;
```
Create Employee Table:
```sql

CREATE TABLE dbo.Employee(
EmployeeId int IDENTITY(1,1),
EmployeeName nvarchar(500),
Department nvarchar(500),
DateOfJoining datetime,
PhotoFileName nvarchar(500),
PRIMARY KEY(EmployeeId)
)

INSERT into dbo.Employee(EmployeeName, Department, DateOfJoining, PhotoFileName)
values ('Bob', 'IT', '2021-06-21', 'anonymous.png');

select * from dbo.Employee;
```
