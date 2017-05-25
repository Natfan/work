CREATE TABLE Member {
	MemberID INT NOT NULL,
	Forname VARCHAR(20),
	Surname VARCHAR(20),
	MaxBooks INT
	DateOfBirth VARCHAR(6), /* or `Date` */
	PRIMARY KEY (MemberID);

	SELECT BookID, Title, Author, Price, Category
	FROM Book
	WHERE Author="David Ferguson" AND Price < 25.00
	ORDER BY Price DESC;
}
