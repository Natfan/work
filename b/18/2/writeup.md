# Unit XVIII Assignment II
*By Nathan Windisch*

## PIII: Implementing a Database
The following screenshots are the tables that I have made within my database. They all have no redundant data within them, and they all have 10 rows of data that follow the data dictionary, which can be seen on the next page.

The following image is the Customers table.

<img src="https://github.com/Natfan/work/raw/master/b/18/2/pics/3-1.png" style="width: 75%;"></img>

The following image is the Employees table.

<img src="https://github.com/Natfan/work/raw/master/b/18/2/pics/3-2.png" style="width: 75%;"></img>

The following image is the Products table.

<img src="https://github.com/Natfan/work/raw/master/b/18/2/pics/3-3.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

The following is the aforementioned data dictionary.

| Field Name | Data Type | Maximum Field Length | Description
|-|-|-|-
| EmployeeID | UUID | 16 Characters | Used as a unique identifier for each employee
| EmployeeName | String | 64 Characters | Used as a human readable format for identifying customers
| EmployeeRole | String | 16 Character | Used for the permission system
| RoleDescription | String | 128 Character | A brief description of their role
| RoleWageMin | Double | 10 Digits | The minimum amount that a person in that role can be paid
| RoleWageMax | Double | 10 Digits | The maximum amount that a person in that role can be paid
| CustomerID | UUID | 16 Characters | used as a unique identifier for each customer
| CustomerName | String | 64 Characters | Used as a human readable format for identifying customers
| CustomerBalance | Double | 10 Digits | The amount of credits that the customer has
| CustomerAddress | String | 64 Characters | The address of the customer
| CustomerPostcode | String | 8 Characters | The postcode of the customer
| CustomerPhoneNumber | Integer | 15 Characters | Either the mobile or the landline number of the customer
| ItemID | UUID | 16 Characters | Used as a unique identifier for each item
| ItemName | String | 64 Characters | Used as a human readable format for identifying items
| ItemPrice | Double | 10 Digits | The price of the item
| ItemDescription | String | 128 Characters | A brief description of the product
| ItemTags | ArrayList<String> | 64 Characters Per Entry | A list of tags that can be applied to the item

<div style="page-break-after: always;"></div>

## PIV: Forms
The following form is a form which allows users to search though the Products table. The following image is taken from that search query:

<img src="https://github.com/Natfan/work/raw/master/b/18/2/pics/4-1.png" style="width: 75%;"></img>

This is the output that it will give:

| ProductID | ProductName | UnitPrice | ProductDescription | CategoryID |
|-|-|-|-|-|
| 1 | Clearance | 250 | Garden Clearance.. | 1 |

This is another query that has been made with this form:

<img src="https://github.com/Natfan/work/raw/master/b/18/2/pics/4-2.png" style="width: 75%;"></img>

This is the output that it will give:

| ProductID | ProductName | UnitPrice | ProductDescription | CategoryID |
|-|-|-|-|-|
| 1 | Clearance | 250 | Garden Clearance.. | 1 |
| 2 | Maintenance | 2000 | Garden Maintenance.. | 1 |
| 3 | Tidying | 300 | Garden Tidying.. | 1 |
| 4 | Redesign | 5000 | Garden Redesign.. | 1 |


