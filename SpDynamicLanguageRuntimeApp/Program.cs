using System.Dynamic;
using System.Threading.Channels;

dynamic Person = new ExpandoObject();

Person.Name = "Bobby";
Person.Age = 25;
Person.Langs = new List<string>() { "C++", "JavaScript", "C#" };

Person.Print = (Action)(() => Console.WriteLine($"Name: {Person.Name} Age: {Person.Age}"));
Person.Print();

foreach(var l in  Person.Langs)
    Console.WriteLine(l);



dynamic bob = new Employee();
bob.Name = "Bobby";
bob.Age = 25;
bob.Salary = 50000m;

Func<decimal, decimal> addSalary = (decimal amount) =>
{
    bob.Salary += amount;
    return bob.Salary;
};

bob.AddSalary = addSalary;
bob.AddSalary(30000m);
Console.WriteLine(bob.Salary);


class Employee : DynamicObject
{
    Dictionary<string, object> members = new Dictionary<string, object>();

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if(value is not null)
        {
            members[binder.Name] = value;
            return true;
        }

        return false;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        result = null;
        if(members.ContainsKey(binder.Name))
        {
            result = members[binder.Name];
            return true;
        }

        return false;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        result = null;
        if(members.ContainsKey(binder.Name))
        {
            if(args.Length == 1 && args?[0] is decimal amount)
            {
                dynamic method = members[binder.Name];
                result = method.Invoke(amount);
            }
        }

        return result != null;
    }
}