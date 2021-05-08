create database Personnel

create table Employee(
	employeeId INT NOT NULL PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	position VARCHAR(50) NOT NULL,
	hourlyRate decimal NOT NULL
)

insert into Employee
values
	(1, 'Abhishek Sawant', 'Software Developer', 26.00),
	(2, 'Konrad Gaerdes', 'Software Developeryy', 26.00),
	(3, 'Rupal Pandya', 'Database Administrator', 26.00),
	(4, 'Sagar Mate', 'Senior Manager', 36.00),
	(5, 'Vaibhav Prasad', 'Team Lead', 28.00),
	(6, 'Sergio Ramos', 'SME', 25.00),
	(7, 'Virjil Van Dijk', 'SME', 25.00),
	(8, 'Roberto Firmino', 'System Analyst', 64.00)

select * from Employee
