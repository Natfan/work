# Unit XVIII Assignment II
*By Nathan Windisch*

## PIII: Implementing a Database
The following screenshots are the tables that I have made within my database. They all have no redundant data within them, and they all have 10 rows of data that follow the data dictionary, which can be seen on the next page.

The following image is the Customers table.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/customerstable.png" style="width: 75%;"></img>

The following image is the Employees table.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/gardenerstable.png" style="width: 75%;"></img>

The following image is the Jobs table.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/jobstable.png" style="width: 75%;"></img>

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
The following form is a form which allows users to search though the Jobs table. The following image is taken from that search query:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/jobsquery.png" style="width: 75%;"></img>

This is the output that it will give if the values in the query are set to be "ProductID == 1":

| JobID | JobName | JobPrice | AssignedGardener | AssignedCustomer |
|-|-|-|-|-|
| 1 | Clearance | 250 | 7 | 3 |

Other queries can be made with this form, and this is the output that it will give if the values in the query are set to "AssignedCustomer == 3":

| JobID | JobName | JobPrice | AssignedGardener | AssignedCustomer |
|-|-|-|-|-|
| 1 | Clearance | 250 | 7 | 3 |
| 2 | Maintenance | 2000 | 3 | 3 |
| 3 | Tidying | 300 | 5 | 3 |
| 4 | Redesign | 5000 | 9 | 3 |

<div style="page-break-after: always;"></div>

The following is a secondary form that is used for adding data to the database. It requires a password so that the user can verify that they have the correct access:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/jobsquery2.png" style="width: 75%;"></img>

And this is a hypothetical outcome that the form being filled out could create:

| GardenerID | GardenerFirstName | GardenerLastName |
|-|-|-|
| 10 | David | Tennant |

<div style="page-break-after: always;"></div>

## PV: Querying the Database
I shall now create some reports that show the results of the database being queried. I shall show the total sales of the business, the top five customers and the total amount of customers to gardeners.

The following image is the output of the total sales:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/salesquery.png" style="width: 75%;"></img>

The following image is the output of the top five customers:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/top5query.png" style="width: 75%;"></img>

The following image is the output of the amount of customers per gardener:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/customerspergardenerquery.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

## PVI: Form Themes
The following image is a form that has been stylised to be more appealing to the user with a bright yellow background, navigation at the top in the form of breadcrumbs so that the user can go to previous sections, and a dropdown box to allow easier data addition, which will auto update the entire form when any of the boxes are changed.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/themedform.png" style="width: 75%;"></img>

The following image is the same form but with different data that has been auto-updated.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/themedform2.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

## PVII: Testing and Logging
### Test Log
| ID | Date | Summary | Details | Expected Outcome | Passed? | Problem ID |
|-|-|-|-|-|-|-|
| 1 | 18/3/17 | Form Gardener First Name Entry Check | Check if input is text and one word only | Only one word with no numbers/symbols can be inputted | Yes | N/A |
| 2 | 18/3/17 | Form Gardener Last Name Entry Check | Check if input is text and one word only | Only one word with no numbers/symbols can be inputted | Yes | N/A |
| 3 | 18/3/17 | Form Customer First Name Entry Check | Check if input is text and one word only | Only one word with no numbers/symbols can be inputted | Yes | N/A |
| 4 | 18/3/17 | Form Customer Last Name Entry Check | Check if input is text and one word only | Only one word with no numbers/symbols can be inputted | Yes | N/A |
| 5 | 18/3/17 | Form Customer First Name Entry Check | Check if input is text and one word only | Only one word with no numbers/symbols can be inputted | Yes | N/A |
| 6 | 18/3/17 | Generate Bill Report | Check if the bill will be generated | A bill will be generated with dynamically changed with the new data | Yes | N/A |
| 7 | 18/3/17 | Generate Top5 Report | Check if the top five list will be generated | A list of the top five customers will be generated with dynamically changed with the new data | Yes | N/A |
| 8 | 18/3/17 | Generate Total Sales Report | Check if the sales list will be generated | A list of all the sales will be generated with dynamically changed with the new data | Yes | N/A |
| 9 | 18/3/17 | Print Bill via Linux | Check if the bill can be printed on Linux | The bill will be sent to the printer | Yes | N/A |
| 9 | 18/3/17 | Print Bill via Windows | Check if the bill can be printed on Windows | The bill will be sent to the printer | No | 1 |
| 10 | 18/3/17 | Referential Integrity | Check if the database has referential integrity | The database will have referential integrity | Yes | N/A |

### Fault Log
| Problem ID | Test ID | Problem | Solution |
|-|-|-|-|
| 1 | 9 | The bill wouldn't print on Linux | Create a new method for printing via Linux, see D2 |

<div style="page-break-after: always;"></div>

## MII: Importing Data
The following image is the file that I was going to use to import:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import1.png" style="width: 75%;"></img>

I used a wizard within Access to help me import the data, as follows:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import2.png" style="width: 75%;"></img>

In the above image I set the data to append to the end of the table.

I came across an error which was caused by the fact that I already had the table open, so I had to close it:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import3.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

In the image below I had to confirm that all of the data was in the right column, which it was:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import4.png" style="width: 75%;"></img>

In the next image, I had to confirm what table I wanted to import the data to, and confirm if I wanted the wizard to analyse my data:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import5.png" style="width: 75%;"></img>

Here, I had to start the analysis:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import6.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

This was the first part of the analysis wizard, it started by explaining what one of the issues might be:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import7.png" style="width: 75%;"></img>

Next, it showed me how it was going to fix the problem:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import8.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

I wanted to decide what I was going to do, so that I could have full control over the data:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import9.png" style="width: 75%;"></img>

I confirmed that all of the data is correct, as seen below:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import10.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

I split the table in two, so that the main lookup could be done in the "primary" table, `CID`, and the secondary data which might not be unique was in the "secondary" table, `CData`.

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import11.png" style="width: 75%;"></img>

I did not want to create a new query:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import12.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

The data was successfully imported:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import13.png" style="width: 75%;"></img>

Albeit, the columns were a tad unordered:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import14.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

Fixed, but the IDs were a bit odd...

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import15.png" style="width: 75%;"></img>

Because I was looking at the `CData` table:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import16.png" style="width: 76%;"></img>

<div style="page-break-after: always;"></div>

This meant that the IDs were not the same as the Customer IDs, which were in a separate table. The data is much more compact there:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/import17.png" style="width: 76%;"></img>

<div style="page-break-after: always;"></div>

## MIII: Exporting Data
I used a wizard within Access to help me export the data, as follows:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/export1.png" style="width: 75%;"></img>

The following image is the outcome that was generated, an Excel file with all of the data:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/export2.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

This is the final step to show that everything was successful:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/export3.png" style="width: 75%;"></img>

<div style="page-break-after: always;"></div>

## MIV: Advanced Features
The following image is of the main form which has a button on it that will print the bills when pressed:

<img src="https://raw.githubusercontent.com/Natfan/work/master/b/18/2/img/jobsquery2.png" style="width: 75%;"></img>

The following is the code, written in Python

```python
import subprocess

def print():
    printfile = open("print.txt", r)

    if platform.system() == "Linux" or platform.system() == "linux":
        lpr =  subprocess.Popen("/usr/bin/lpr", stdin=subprocess.PIPE)
        print("starting to print the file")
        lpr.stdin.write(printfile)
        print("file printing finished")
    else:
        print("your operating system is not currently supported")

print()
```

The code will also be executed whenever an order has been completed.

<div style="page-break-after: always;"></div>

## DII: Feedback
When I decided to start to look for feedback, I created a questionnaire with the following questions and format:

>Please rate the following questions that are prepended with an `*` out of 5, where 1 is terrible and 5 is excellent.

>> \*Appearance:
>>
>> \*Legibility:
>>
>> \*Ease of Access:
>>
>> \*Extensive Features:
>>
>> \*Intuitive Design:
>>
>> \*Overall Satisfaction:
>>
>> Improvement Suggestions:

I gave the questionnaire to one of my customers, Ryan Krage. The following are his answers.

>Please rate the following questions that are prepended with an `*` out of 5, where 1 is terrible and 5 is excellent.
>
>> \*Appearance: 4
>>
>> \*Legibility: 5
>>
>> \*Ease of Access: 5
>>
>> \*Extensive Features: 1
>>
>> \*Intuitive Design: 5
>>
>> \*Overall Satisfaction: 4
>>
>> Improvement Suggestions: The code to print the bill didn't work.

I took the criticisms given to me on-board and rewrote the code to work with the client's Windows setup, as the previous iteration of the code only worked with Linux. I added an option feature at the start of the program for the user to select what operating system they were running.

```python
import platform
import subprocess

def print():
    printfile = open("print.txt", r)

    if platform.system() == "Windows" or platform.system() == "windows":
        print("starting to print the file")
        win32api.ShellExecute(
            0,
            "print",
            printfile,
            '/d:"%s"' % win32print.GetDefaultPrinter (),
            ".",
            0
        )
        print("file printing finished")
    elif platform.system() == "Linux" or platform.system() == "linux":
        lpr =  subprocess.Popen("/usr/bin/lpr", stdin=subprocess.PIPE)
        lpr.stdin.write(printfile)
    else:
        print("your operating system is not currently supported")

print()
```
