# MathExtended.Matrix
C# Library for Matrices


## Legal information and credits

ImageProcessing is project by Ales Hotko and was first released in April 2018. It's licensed under the MIT license.

## Usage

```csharp
//Create square matrix of size 3x3
Matrix matrix = new Matrix(3);

//-...or a matrix of any size (i.e. 5x3)
Matrix matrix = new Matrix(5, 3);

//Populate Matrix
matrix[1, 1] = 5.0;
matrix[1, 2] = 5.0;
matrix[1, 3] = 5.0;

//operations
Matrix a = new Matrix(3, 3);
Matrix b = new Matrix(3, 3);

//addition
Matrix sum = a + b;
//..or..
a.Add(b);

//multiplication with scalar
Matrix product = a * 3.0;
//..or..
a.Multiply(3.0);
//Hadamard Product
a.HadamardProduct(b);

//multiplication with another matrix
Matrix product = a * b;
//..or..
a.Multiply(b);

//Inversion
Matrix inverse = ~a;
//..or..
a.Inverse();

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

//Transormations
//2D
Matrix rotation2D = Matrix.Rotation2D(angleInDegrees);
//3D around X, Y or Z axis
Matrix rotation3D = Matrix.Rotation3DX(angleInDegrees);
Matrix rotation3D = Matrix.Rotation3DY(angleInDegrees);
Matrix rotation3D = Matrix.Rotation3DZ(angleInDegrees);

//Scaling
Matrix scaling = Matrix.Scaling(factorX, factorY, factorZ);

//Translation
Matrix translation = Matrix.Translation(moveX, moveY, moveZ);

//Various
//Zero matrix
Matrix zero = Matrix.Zero(rows, cols);
//..or..
Matrix zeroSquare = Matrix.Zero(size);
//Identity
Matrix identity = Matrix.Identity(size);

//Randomize
Matrix random = new Matrix(5);
//for random elements between -5.0 and 10.0
random.Randomize(-5,0, 10.0);
//..or for random elements between 0 and 1
random.Randomize();

//Transposition
Matrix r = new Matrix(5, 4);
r.Transpose();

//Map elements with a function
Matrix r = new Matrix(5, 4);
r.Randomize();
r.Map(Math.Sin);
//or own function
public double MyFunction(double param)
{
	return param * 42.0;
}

[...]
r.Map(MyFunction);
[...]
```