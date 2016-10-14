using System;
using System.Web.UI;
using System.Web.Compilation;
using System.CodeDom;
using System.ComponentModel;

public class RandomNumberExpressionBuilder : ExpressionBuilder
{
	public static string GetRandomNumber(int lowerLimit, int upperLimit)
	{
		Random rand = new Random();
		int randValue = rand.Next(lowerLimit, upperLimit + 1);
		return randValue.ToString();
	}

	public override CodeExpression GetCodeExpression(
		BoundPropertyEntry entry, object parsedData,
		ExpressionBuilderContext context)
	{
		// entry.Expression is the number string
		// (minus the RandomNumber: prefix).
		if (!entry.Expression.Contains(","))
		{
			throw new ArgumentException("Must include two numbers separated by a comma.");
		}
		else
		{
			// Get the two numbers.
			string[] numbers = entry.Expression.Split(',');

			if (numbers.Length != 2)
			{
				throw new ArgumentException("Only include two numbers.");
			}
			else
			{
				int lowerLimit, upperLimit;
				if (Int32.TryParse(numbers[0], out lowerLimit) &&
					Int32.TryParse(numbers[1], out upperLimit))
				{

					// So far all the operations have been performed in
					// normal code. That's because the two numbers are
					// specified in the expression, and so they won't
					// change each time the page is requested.
					// However, the random number should be allowed to
					// change each time, so you need to switch to CodeDOM.					
					
                    // Get a reference to the class that has the GetRandomNumber() method.
                    // (It's the class where this code is executing.)
                    CodeTypeReferenceExpression typeRef = new CodeTypeReferenceExpression(this.GetType());

                    // Define the parameters that need to be passed to GetRandomNumber().
                    CodeExpression[] methodParameters = new CodeExpression[2];
                    methodParameters[0] = new CodePrimitiveExpression(lowerLimit);
                    methodParameters[1] = new CodePrimitiveExpression(upperLimit);

                    // Define the code expression that invokes GetRandomNumber().
                    CodeMethodInvokeExpression methodCall = new CodeMethodInvokeExpression(typeRef, "GetRandomNumber", methodParameters);

                    // The commented lines allow you to perform casting.
                    // It's not required in this example (as GetRandomNumber returns a string),
                    // but it's a common expression builder technique.
                    //Type type = entry.DeclaringType;
                    //PropertyDescriptor descriptor = TypeDescriptor.GetProperties(type)[entry.PropertyInfo.Name];
                    //return new CodeCastExpression(descriptor.PropertyType, methodCall);
                    
                    return methodCall;
				}
				else
				{
					throw new ArgumentException("Use valid integers.");
				}

			}
		}
		
	}
}


