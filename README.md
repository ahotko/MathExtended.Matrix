# MathExtended.Matrix
C# Library for Matrices


## Legal information and credits

ImageProcessing is project by Ales Hotko and was first released in April 2018. It's licensed under the MIT license.

## Usage

### Matrix Creation
##### Square Matrix
```csharp
//Create square matrix of size 3x3
Matrix matrix = new Matrix(3);
```
##### Matrix of any size
```csharp
//...or a matrix of any size (i.e. 5x3)
Matrix matrix = new Matrix(5, 3);
```
##### Zero Matrix
```csharp
Matrix zero = Matrix.Zero(rows, cols);
//..or..
Matrix zeroSquare = Matrix.Zero(size);
```
##### Identity Matrix
```csharp
Matrix identity = Matrix.Identity(size);
```
### Populating the matrix
```csharp
//Populate Matrix
matrix[1, 1] = 5.0;
matrix[1, 2] = 5.0;
matrix[1, 3] = 5.0;
//...or populate with random values between -5.0 and 10.0
matrix.Randomize(-5,0, 10.0);
//..or with random values between 0 and 1
matrix.Randomize();
```
### Math operations
```csharp
Matrix a = new Matrix(3, 3);
Matrix b = new Matrix(3, 3);
```
##### Addition
```csharp
Matrix sum = a + b;
//..or..
a.Add(b);
```
##### Multiplication
```csharp
//multiplication with scalar
Matrix product = a * 3.0;
//..or..
a.Multiply(3.0);
//multiplication with another matrix
Matrix product = a * b;
//..or..
a.Multiply(b);
```
##### Hadamard Product
```csharp
a.HadamardProduct(b);
```
##### Inversion
```csharp
Matrix inverse = ~a;
//..or..
a.Inverse();
```
##### Transposition
```csharp
Matrix r = new Matrix(5, 4);
r.Transpose();
```
##### Mapping elements with a function
```csharp
Matrix r = new Matrix(5, 4);
r.Map(Math.Sin); //Apply Sine function to every matrix element
//or own function
public double MyFunction(double param)
{
	return param * 42.0;
}

[...]
r.Map(MyFunction);
[...]
```
### Comparing the matrices
```csharp
//Equality
if(a == b) {}
//..or..
if(a != b) {}
//..or..
if(a > b) {}
//..or..
if(a < b) {}
//..or..
if(a >= b) {}
//..or..
if(a <= b) {}

```
### Creating Transformation Matrices
#### Rotation
```csharp
//2D
Matrix rotation2D = Matrix.Rotation2D(angleInDegrees);
//3D around X, Y or Z axis
Matrix rotation3D = Matrix.Rotation3DX(angleInDegrees);
Matrix rotation3D = Matrix.Rotation3DY(angleInDegrees);
Matrix rotation3D = Matrix.Rotation3DZ(angleInDegrees);
```
#### Scaling
```csharp
Matrix scaling = Matrix.Scaling(factorX, factorY, factorZ);
```
#### Translation
```csharp
Matrix translation = Matrix.Translation(moveX, moveY, moveZ);
```


