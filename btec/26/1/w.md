# Unit XXVI Assignment I: Matrices
*By Nathan Windisch*

## Data
The following data is used in PII, PIII and PIV,

```
 M = [  3 -1 ]
     [  4  2 ]
```

```
 N = [  4  3 ]
     [ -3 -1 ]
```

```
     [  1 3 5 ]
 P = [ -1 2 4 ]
     [ -3 4 3 ]
```

```
     [ 2  3  3 ]
 Q = [ 4  4 -2 ]
     [ 2 -4  8 ]
```

```
 R = [  9  2  6 ]
     [ 12 -4  7 ]
```

```
     [ -6  3 ]
 S = [ -3 -2 ]
     [ -6  6 ]
```

<pagebreak>

## PI: Understanding Matrices and How Matrices Can Be Used To Represent Ordered Data
### Overview
A Matrix is a way of displaying data in an ordered format. Matrices are in a rectanguar format with cells comprised of rows and columns. Matrices can be used with one another to add, subtract and multiply. When writing out a matrix calculation, regular mathematical symbols are used, except for the full stop symbol (.), which is used for multiplcation of matrices. When multipling matrices, the order of which matrix comes first is key. `A . B` is not the same as `B . A`.

### Order
The order of a matrix is very important. A matrix with the numbers `[3, 6] [9, 5]` will have a different outcome if manipulated with another number than a matrix with the numbers `[6, 3] [5, 9]`. This means that if the order of any individual number is changed, the whole calculation could be invalidated.

### Indecies
Indexes of matrices are selected subsections of a matrix. For instance, a 3x3 matrix may be like this;

```
[9 2 8]
[3 1 4]
[7 6 5]
```

But an index of the matrix would be only a small group, such as this 2x2 subsection.

```
[3 1]
[7 6]
```

### Real World Applications
Matrices can be used in the real world in many different applications. One use of matrixes in the real world is the traits of a population of people, webpage rankings and cryptography. Without matrices, many real world applications would be hindered.

<pagebreak>

## PII: Adding & Subtracting Matrices

The following questions need to be answered:

a. M + N
b. P + Q
c. M - N
d. 3P
e. 3P - 2Q

The following are my answers to the question, with working out added to them as an intermediate step.

```
a. M + N = [3 -1]   [ 4  3]   [(3+ 4) (-1+ 3)]   [7 2]
           [4  2] + [-1 -1] = [(4+-3) ( 2+-1)] = [1 1]
```

```
           [ 1 3 5]   [2  3  3]   [( 1+2) (3+ 3) (5+ 3)]   [3 6  8]
b. P + Q = [-1 2 4] + [4  4 -2] = [(-1+4) (2+ 4) (4+-2)] = [3 6  2]
           [-1 4 3]   [3 -4  8]   [(-1+3) (4+-4) (3+ 8)]   [2 0 11]
```

```
c. M - N = [3 -1]   [ 4  3]   [(3- 4) (-1- 3)]   [(3-4) (-1-3)]   [-1 -4]
           [4  2] - [-3 -1] = [(4--3) ( 2--1)] = [(4+3) ( 2+1)] = [ 7  3]
```

```
        [ 1 3 5]       [( 1*3) (3*3) (5*3)]   [ 3  9 15]
d. 3P = [-1 2 4] * 3 = [(-1*3) (2*3) (4*3)] = [-3  6 12]
        [-1 4 3]       [(-1*3) (4*3) (3*3)]   [-3 12  9]
```

```
             ([ 1 3 5]  )   ([2  3  3]  )   [( 1*3) (3*3) (5*3)]   [(2*2) ( 3*2) ( 3*2)]   [ 3  9 15]   [4  6  6]   [( 3+4) ( 9+ 6) (15+ 6)]   [7 15 21]
e. 3P + 2Q = ([-1 2 4]*3) + ([4  4 -2]*2) = [(-1*3) (2*3) (4*3)] + [(4*2) ( 4*2) (-2*2)] = [-3  6 12] + [8  8 -4] = [(-3+8) ( 6+ 8) (12+-4)] = [5 14  8]
             ([-1 4 3]  )   ([2 -4  8]  )   [(-1*3) (4*3) (3*3)]   [(3*2) (-4*2) ( 8*2)]   [-3 12  9]   [6 -8 16]   [(-3+6) (12+-8) ( 9+16)]   [3  4 25]
```

<pagebreak>

## PIII: Multiplying Matrices

The following questions need to be answered:

*Please note that . is equal to x.*

a. M.N
b. P.Q
c. R.S
d. S.R

The following are my answers to the questions, along with the working out added to then as an intermediate step.

```
a. M . N = [3 -1]   [ 4  3]   [(3* 4) (-1* 3)]   [ 7 -3]
           [4  2] . [-1 -1] = [(4*-1) ( 2*-1)] = [-4 -2]
```

```
           [ 1 3 5]   [2  3  3]   [ (1*2) (3* 3) (5* 3)]   [ 2   9 15]
b. P . Q = [-1 2 4] . [4  4 -2] = [(-1*4) (2* 4) (4*-2)] = [-4   8 -8]
           [-3 4 3]   [2 -4  8]   [(-3*2) (4*-4) (3* 8)]   [-6 -16 24]
```

```
                       [-6  3]
c. R . S = [ 9  2 6] . [-3 -2] = [( 9*-6+ 2*-3+6*-6) ( 9*3+ 2*-2+6*6)] = [- 96 59]
           [12 -4 7]   [-6  6]   [(12*-6+-4x-3+7*-6) (12*3+-4*-2+7*6)]   [-102 86]
```

```
           [-6  3]               [-6*9+3*12-3*9+-2*12-6*9+6*12]   [-18 -24 -15]
d. S . R = [-3 -2] . [ 9  2 6] = [-6*2+3*-4-3*2+-2*-4-6*2+6*-4] = [-51   2 -32]
           [-6  6]   [12 -4 7]   [-6*6+3* 7-3*6+-2* 7-6*6+6* 7]   [ 18 -36   6]
```

<pagebreak>

## PIV: Inverse and Transpose
The following questions need to be answered:

*Please note that x/y is the same as x over y .*

a. M⁻¹
b. N⁻¹
c. P⁻¹
d. Q⁻¹
e. M^T
f. P^T
g. R^T

The following are my answers to the questions, along with the working out added to them as an intermediate step.

For reference, when calculating the inverse of a matrix you need to calculate the inverse of each individual element.

`TODO: UP TO HERE`
```
a. M⁻¹= [3 -1]⁻¹   [ 1/5 1/10]
        [4  2]   = [-2/5 3/10]
```

```
b. N⁻¹ =  [ 4  3]⁻¹   [ 1  3]
          [-1 -1]   = [-1 -4]
```

```
c. P⁻¹ = [-1 24]⁻¹   [43/29 -24/29]
         [-3 43]   = [ 3/29  -1/29]

```

```
         [2  33]⁻¹
d. Q⁻¹ = [4 -42]   = Undefined as the matrix needs to be a square for an inverse to be found.
         [2 -48]
```

```
e. M^T = [3 -1]^T   [3  4]
         [4  2]   = [-1 2]
```

```
         [ 1 35]^T   [ 1 -1 -3]
f. P^T = [-1 24]   = [35 24 43]
         [-3 43]
```

```
         [ 2  3 3]^T   [2 9 12]
g. R^T = [ 9  2 6]   = [3 2 -4]
         [12 -4 7]     [3 6  7]
```

<pagebreak>

# PV: Simulations Equations

The following questions need to be answered:

```
a. 3x + 4y = 14
   2x - 7y = 11
```

```
b. 6x + 2y = 24
   3x - 3y = 22
```

The following are my answers to the questions, along with the working out added to them as an intermediate step.

```
a. [3  4] [x] = [14]
   [2 -7] [y]   [11]

   Therefore
   [x] [3  4]⁻¹ = [14]
   [y] [2 -7]     [11]
   And we shall call this matrix 'A' for easier understanding later on.

   1/|A| [3  4] = 1/(3*-7) - (4*2) [3  4] =
         [2 -7]                    [2 -7]

   1/-29 [-7 4] = 1/29 [-7 -4] =
         [ 2 3]        [-2  3]

   [((1/-29)*-7) ((1/-29)*-4)] =
   [((1/-29)*-2) ((1/-29)* 3)]

   A⁻¹ = [7/29  4/ 29]
         [2/29 -3/-29]

   The next step is to inverse 'A' by the original 11.14 matrix.

   [x] = [7/29  4/ 29] [14]
   [y]   [2/29 -3/-29] [11]

   [7/29  4/ 29] [14] = [[(7/29)x14] + [( 4/ 29)x11]] = [98/29 +  44/ 29] = [142/ 29]
   [2/29 -3/-29] [11]   [[(2/29)x14]   [(-3/-29)x11]]   [28/29 + -33/-29]   [ -5/-29]

   Ergo:
   [x] = [142/ 29]
   [y]   [ -5/-29]
```

Finally, we can determine that the answer is:
   **x = 142/29**
   **y = -5/-29**

```
b. [6  2] [x] = [24]
   [3 -3] [y]   [22]

   Therefore
   [x] [6  2]⁻¹ = [24]
   [y] [3 -3]     [22]
   And we shall call this matrix 'A' for easier understanding later on.

   1/|A| [6  2] = 1/(6*(-3))- (2*(-3)) [6  2] =
         [3 -3]                        [3 -3]

   1/-24 [-3 2] = 1/-24 [-3 -2] =
         [ 3 6]         [-3  6]

   [((1/-24)*-3) ((1/-24)*-2)] =
   [((1/-24)*-3) ((1/-24)* 6)]

   A⁻¹ = [1/8  1/12]
         [1/8 -1/-4]

   The next step is to inverse 'A' by the original 11.14 matrix.

   [x] = [1/8  1/12] [24]
   [y]   [1/8 -1/-4] [22]

   [1/8  1/12] [24] = [[(1/8)x24] + [( 1/12)x22]] = [3 +  11/ 6] = [29/ 6]
   [1/8 -1/-4] [22]   [[(1/8)x24]   [(-1/-4)x22]]   [3 + -11/-2]   [-5/-2]

   Ergo:
   [x] = [29/ 6]
   [y]   [-5/-2]
```
Finally, we can determine that the final answer is:
  **x = 29/6**
  **y = -5/-2**

<pagebreak>

## MI: Relationship between Matrices and Arrays in Computer Programming
A standardized array has a number of rows and columns. For instance, a 3x2 matrix it would have two columns and three rows, and a 5x5 matrix would have five columns and five rows. Arrays are very similar, but the other way around. A 3x2 matrix would have two rows and three columns, and a 5x5 matrix would have five rows and five columns. Aside from this, the way that arrays are used within programming are very similar to the way that matrices are used, at least in terms of storage. When creating a natrix with one column, one would do something like this:

```
[3]
[4]
[9]
```

The above matrix is a 3x1 matrix. To get the same result when programming, one may do something like the following to get a single dimensional array:

```
var array = [3, 4, 9];
```

The reason why this is called a single dimensional array is because there is only one 'side' to it; there is only one set of numbers meaning that if one were to assign all of these cells a unique identifier, they would be `3:0; 4:1; 9:2` with the first number being the value and the second being the identifier.

A matrix with only one column can't really do much as far as mathematics is concerned. It cannot be used to multiply with anything inside itself, and is generally a useless piece of data. An array with one dimension, on the other hand, in extremely useful as it can store vast quantities of data with ease, allowing for data to be accessed from many new methods, along with manipulating the data to add and remove new cells on the fly. Whilst all of this is good, I shall now compare the similarities between a 2x2 matrix and a two dimensional array.

When making a 2x2 matrix, as seen below, one can do many more things with the data.

```
[4] [9]
[7] [1]
```

It can be used to add, subtract and multiply, along with calculating the inverse and transpositions. It can also be used for generating solutions to simulatious equations. The possiblities are vast, whereas with a two dimensional array, the possible uses are very similar to a single dimensional array. A two dimensional array, as shown below, can be used to store more data than a single dimensional array as other values can be added to the data.

```
var array = [
  [4, 7]
  [9, 1]
];
```

This array can be considered as an "array within an array". It can store the data within the first layer, like the one beofre, but it can also store more data inside it. When assigning unique identifier, it would be displayed like `[4,7]:0; [9,1]:1` for the first layer and `4:0; 7:1 ` for the second layer in the first subarray. This means that multiple layers of data can be stored within one array.

## MII:
