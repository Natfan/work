# Unit XVIII Assignment I
*By Nathan Windisch*

## Task I: Relational Databases
### PI: Business Information, Entities, Attributes and Data Validation
#### Business Information
Business Information is data such as client information, stock information, share information and more. All of these individual pieces of data should be stored in a database to allow easier access to the system, resulting in faster data transference and quicker response times. Databases come in many forms and use different languages such as `SQL` and `dBase`, and can be used in many different ways. The business information that is saved should be encrypted, to prevent unauthorized access of the data, which may be considered sensitive. Encryption of this data is not just a good practice as far as customer relations go, as they know that their data is safe, but it also can be a legal requirement in some countries, meaning that the business is liable if any data is lost or stolen.

#### Entities
Entities are points of data that can be found within a database. Entities are inherently linked to their appropriate entities and are considered to be the unique identifier of the data. Entities can be a single person, place, item of stock or any other "thing" which has properties. Entities can be related to other Entities with a system called normalisation, which is where entities can be connected to one another. Business data can be represented using entities using 

#### Attributes
Attributes are single pieces of data within a database that allows different types of data to be stored. This can include, but is not limited to, certain types of business data such as client information, stock information and share information. All of these data types will have many different entities within them, such as customer first names, dates of births of employees, any allergies that managers may have and more. All of these entities will probably be just one type of data, such as an integer or a character. Most of these primitive data types should already be known as they can be seen in many common programming languages. Other, more specific primitive data types can be found within some database languages, but the most common one is varchar that is found within SQL. While all the previous data types can only contain one type of character (although strings can store integers in a text based format), a varchar can store both characters and integers in a similar format to a string in other programming languages. This means that you can store numbers as text, if the context requires it. It is important to use the correct data types when storing different pieces of information, due to the fact that it can take up less space and it can also mean that the data can be read easier and the data can be accessed and sorted faster. Business information can be stored as attributes, such as a person's name, date of birth or address.

#### Entity Relationship
Entity Relationship is a way of creating diagrams that show how entities can be linked together. This allows database designers to be able to visualise how their database will work, allowing easier access to the system along with easier database population and mapping for future data being added to the system.

#### Data Validation
Data Validation is a method of ensuring that all data within the database is valid and accurate. This can be done by performing checks when the data is entered and throwing an exception if an error is made. Another way that this can be achieved is by only allowing certain data types to be allowed to be entered into a field, such as only integers being allowed for an age to be input. This can be expanded upon to ensure that the data that is input into a Date Of Birth field has six numbers split with a slash, such as `08/09/98` for the `8th September 1998`. Data Validation is a huge part of database management as if the data is not validated and the inputs are not sanitized, then hackers can inject malicious code into the system such as `DROP TABLE Customers;` which will result in the database `Customers` being deleted.

### PII: Designing a Relational Database
#### Normalization
Within databases there are three different forms of normalization.

* **UNF**, or **Unnormalized** is when there is lots of data redundancy and can contain many data structures within a single hallmark.
* **1NF**, or **First Normal Form** is when each field in a table does not contain the same type of information. An example of this would be in a customer list where each table would only contain one phone number.
* **2NF**, or **Second Normal Form** is when each field in a table must be a function of the other fields in the table if it is not a determiner of the contents of that field
* **3NF**, or **Third Normal Form** is when there is absolutely no duplicate information within the table. For example, if two tables both require a phone number field, that information would be placed into a separate table, and the two other tables would then information that they want such as the phone number data, via an index field in the newly created phone number table. Any and all change that are made to a phone number will now automatically update and be reflected to all tables that use the phone number table.

##### Examples
###### UNF
| ID |   Colour   | Price |
|----|------------|-------|
| 01 | red, green | 07.49 |
| 02 |    blue    | 02.24 |
| 03 |   yellow   | 06.87 |
| 04 |  blue, red | 21.05 |

###### 1NF
| ID | Price |
|----|-------|
| 01 | 07.49 |
| 02 | 02.24 |
| 03 | 06.87 |
| 04 | 21.05 |

| ID |   Colour   |
|----|------------|
| 01 | red, green |
| 02 |    blue    |
| 03 |   yellow   |
| 04 |  blue, red |
