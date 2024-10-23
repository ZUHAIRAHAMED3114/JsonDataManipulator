using ExpressionTree.ExpressionTree;



var compileExpression1 = TransformExpression.Eval("2.5*product.weight+(product.height*product.depth)");
var Result1 = compileExpression1(new Dictionary<string, decimal> {
    { "product.weight", 5 },
    { "product.height", 2 },
    { "product.depth", 3 }
});
Console.WriteLine($"{Result1}");

var compileExpression = TransformExpression.Eval("income.rent - expenses.electricity + (bonus * taxrate) - rent");
var Result2 = compileExpression(new Dictionary<string, decimal> {
    { "income.rent", 4000 },
    { "expenses.electricity", 1200 },
    { "bonus", 500 },
    { "taxrate", 0.2m },
    { "rent", 800 }
});

Console.WriteLine($"{Result2}");

 /*
   1) ArgumentNull exception,
   2) typeCast Exception , Any Ojbect Who 
   3) Data lenght MisMatch 
  */
