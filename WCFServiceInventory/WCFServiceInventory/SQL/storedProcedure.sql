--ORDERS
DROP PROCEDURE IF EXISTS sp_SelectOrder
GO
CREATE PROCEDURE sp_SelectOrder 
AS
BEGIN
	select * from orders;
END

DROP PROCEDURE IF EXISTS sp_InsertOrder
GO
CREATE PROCEDURE sp_InsertOrder (
	@orderNo int
	,@purchAmt decimal(6,2)
	,@orderDate Date
	,@customerId int
	,@salesmanId int
	)
AS 
BEGIN
	insert into orders values(@orderNo, @purchAmt, @orderDate, @customerId, @salesmanId)
END

EXEC sp_InsertOrder @orderNo = 70016, @purchAmt= 3052.61, @orderDate = '2012-05-26', @customerId=3003, @salesmanId=5002;

DROP PROCEDURE IF EXISTS sp_UpdateOrder
GO
CREATE PROCEDURE sp_UpdateOrder (
	@orderNo int
	,@purchAmt decimal(6,2)
	,@orderDate Date
	,@customerId int
	,@salesmanId int
	)
AS 
BEGIN
	update orders Set purch_amt=@purchAmt, ord_date=@orderDate, customer_id=@customerId, salesman_id=@salesmanId where order_no = @orderNo
END

DROP PROCEDURE IF EXISTS sp_DeleteOrder
GO
CREATE PROCEDURE sp_DeleteOrder (@orderNo int)
AS 
BEGIN
	delete orders where order_no = @orderNo
END

-- CUSTOMER
DROP PROCEDURE IF EXISTS sp_SelectOrder
GO
CREATE PROCEDURE sp_SelectCustomer 
AS
BEGIN
	select * from customer;
END

DROP PROCEDURE IF EXISTS sp_InsertCustomer
GO
CREATE PROCEDURE sp_InsertCustomer (
	@customerId int
	,@custName varchar(50)
	,@city varchar(50)
	,@grade int
	,@salesmanId int
	)
AS 
BEGIN
	insert into customer values(@customerId, @custName, @city, @grade, @salesmanId)
END

DROP PROCEDURE IF EXISTS sp_UpdateCustomer
GO
CREATE PROCEDURE sp_UpdateCustomer (
	@customerId int
	,@custName varchar(50)
	,@city varchar(50)
	,@grade int
	,@salesmanId int
	)
AS 
BEGIN
	update customer set cust_name = '@custName', city='@city', grade=@grade, salesman_id=@salesmanId where customer_id= @customerId
END

DROP PROCEDURE IF EXISTS sp_DeleteCustomer
GO
CREATE PROCEDURE sp_DeleteCustomer (@customerId int)
AS 
BEGIN
	delete customer where customer_id= @customerId
END

-- SALESMAN
DROP PROCEDURE IF EXISTS sp_SelectSalesman
GO
CREATE PROCEDURE sp_SelectSalesman 
AS
BEGIN
	select * from salesman;
END

DROP PROCEDURE IF EXISTS sp_InsertSalesman
GO
CREATE PROCEDURE sp_InsertSalesman (
	@salesmanId int
	,@name nvarchar(50)
	,@city nvarchar(50)
	,@commission decimal(3,2)
	)
AS 
BEGIN
	insert into salesman values(@salesmanId, @name, @city, @commission)
END

DROP PROCEDURE IF EXISTS sp_UpdateSalesman
GO
CREATE PROCEDURE sp_UpdateSalesman (
	@salesmanId int
	,@name nvarchar(50)
	,@city nvarchar(50)
	,@commission decimal(3,2)
	)
AS 
BEGIN
	update salesman Set name = @name, city = @city, commission = @commission where salesman_id = @salesmanId
END

DROP PROCEDURE IF EXISTS sp_DeleteSalesman
GO
CREATE PROCEDURE sp_DeleteSalesman (@salesmanId int)
AS 
BEGIN
	delete salesman where salesman_id = @salesmanId
END

EXEC sp_DeleteSalesman @salesmanId=5006;