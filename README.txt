Api desenvolvida com:
.Net Core 2;
Entity Framework Core;
SQLExpress
Unity para injeção de dependencias
Possui testes unitários;
Pode ser testada via Postman utilizando a seguinte estrutura json:
{
	IdStore: 1,
	CreditCardBrand: 1,
	CreditCardNumber : "4111111111111111",
	ExpMonth : "10",
	ExpYear : "22",
	SecurityCode : "123",
	HolderName : "LUKE SKYWALKER",
	IsTest : false
}
