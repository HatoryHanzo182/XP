# Basic course on the methodology of extreme programming

This project was created for educational purposes, with the aim of learning the XP (Extreme Programming) methodology and developing C# programming skills.

## Description of the project

The XP Project is a set of classes and unit tests designed to demonstrate XP principles in software development. The project covers various aspects, such as creating classes, writing tests, and using the XP methodology in the development process.

## Classes

The project includes the following classes:

1. **RomanNumber** - The overall purpose of the class is to provide the ability to convert Roman numerals to integers and back, and to provide a string representation of Roman numerals. This class is useful for working with Roman numerals in a program, allowing you to perform operations on them and output the results in a readable format.

## Unit tests

The project also includes a set of unit tests developed using a unit testing framework to test the functionality of the classes. Some of the tests are listed below:

1. **TestParse** - The unit testing method verifies the correct conversion of Roman numerals to their integer values. It includes a dictionary of test cases where each key represents a string of Roman numerals and the corresponding value is the expected integer value when parsing that Roman numeral. The method then states that parsing each string of Roman numerals results in the expected integer value. This extensive set of test cases ensures the accuracy of the Roman numeral parsing logic and covers a wide range of scenarios.

2. **TestException** - This method verifies that the RomanNumber.Parse() method correctly throws exceptions in response to invalid input. It covers scenarios such as a null value, an empty string, and a string with illegal Roman numeral characters. Each test case is checked for a corresponding exception with the correct error message.

3. **TestParseInvalid** - Verifies that the RomanNumber.Parse() method correctly handles input containing invalid characters. It tests cases in which the input contains spaces and non-numeric characters. For each invalid character, the method checks that an appropriate exception is thrown with the correct error message.

4. **TestParseDubious** - Explores cases where Roman numerals may be considered questionable or non-standard. It checks that the RomanNumber.Parse() method handles such cases and does not return null for such input. In addition, it verifies that the method correctly parses questionable input and returns the expected integer value.

5. **TestToString** - Verifies that the RomanNumber.ToString() method correctly converts integer values to their Roman numeral representations. It includes an extensive set of test cases covering a wide range of positive and negative integer values.

5. **CrossTestParseToString** - Cross-tests the RomanNumber class by converting integer values to their Roman numeral representations using the RomanNumber.ToString() method, and then parsing those Roman numerals back to integers using the RomanNumber.Parse() method. This ensures consistency and accuracy of conversion between integers and Roman numerals.

6. **TypesFeatures** - Checks that the RomanNumber(int) constructor correctly sets the value of the RomanNumber object to the number passed in. If your RomanNumber class is implemented correctly and this constructor works correctly, then this test will pass.

7. **TestPlus** - Is designed to test various aspects of the Plus method of the RomanNumber class, including argument validation and the correctness of the addition results.

7. **TestSum** - This set of test cases satisfies various aspects of the RomanNumber.Sum method, including correct addition, null handling, and random tests to ensure that the method works correctly.

## Teacher

This project was written under the direction of [denniksam](https://github.com/denniksam) computer academy step
