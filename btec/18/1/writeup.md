# Unit XVIII Assignment I
*By Nathan Windisch*

## Task I: Relational Databases

### PI: Business Information, Entities, Attributes and Data Validation
#### Business Information
Business Information is data such as client information, stock information, share information and more. All of these individual pieces of data should be stored in a database to allow easier access to the system, resulting in faster data transference and quicker response times. Databases come in many forms and use different languages such as `SQL` and `dBase`, and can be used in many different ways. The business information that is saved should be encrypted, to prevent unauthorized access of the data, which may be considered sensitive. Encryption of this data is not just a good practice as far as customer relations go, as they know that their data is safe, but it also can be a legal requirement in some countries, meaning that the business is liable if any data is lost or stolen. 

#### Entities
Entities are points of data that can be found within a database. Entities are inherently linked to their appropriate entities and are considered to be the unique identifier of the data. Entities can be a single person, place, item of stock or any other "thing" which has properties. Entities can be related to other Entities with a system called normalisation, which is where entities can be connected to one another.

#### Attributes 
Attributes are single pieces of data within a database that allows different types of data to be stored. This can include, but is not limited to, certain types of business data such as client information, stock information and share information. All of these data types will have many different entities within them, such as customer first names, dates of births of employees, any allergies that managers may have and more. All of these entities will probably be just one type of data, such as an integer or a character. Most of these primitive data types should already be known as they can be seen in many common programming languages. Other, more specific primitive data types can be found within some database languages, but the most common one is varchar that is found within SQL. While all the previous data types can only contain one type of character (although strings can store integers in a text based format), a varchar can store both characters and integers in a similar format to a string in other programming languages. This means that you can store numbers as text, if the context requires it. It is important to use the correct data types when storing different pieces of information, due to the fact that it can take up less space and it can also mean that the data can be read easier and the data can be accessed and sorted faster. Business information can be stored as attributes, such as a person's name, date of birth or address.

#### Entity Relationship
Entity Relationship is a way of creating diagrams that show how entities can be linked together. This allows database designers to be able to visualise how their database will work, allowing easier access to the system along with easier database population and mapping for future data being added to the system. 

#### Data Validation

