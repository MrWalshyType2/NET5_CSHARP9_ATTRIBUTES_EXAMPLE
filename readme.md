# Attributes
Attributes allow metadata or declarative information to be associated with code (assemblies, types, methods, properties, etc...).

When an attribute is associated with an entity, the attribute is queryable at runtime using reflection.

## Using an attribute
Attributes can be placed on most declarations, although this can be restricted inside the attribute.

Applying the `Serializable` attribute to a class:
```
[Serializable]
public class Sample
{
	// Objects of this type are serializable
}
```

## Creating an attribute
Attributes can be created by creating an attribute class that derives directly or indirectly from `Attribute`.

### Apply the AttributeUsageAttribute
A custom attribute will begin with the `System.AttributeUsageAttribute`, this specifies whether an attribute can be inherited
or which elements the attribute can be applied to.
```
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
```

#### AttributeTargets
The `AttributeTargets` attribute indicates which program elements the attribute is appliable to. `.All` means everything, `.Class` means
only classes, `.Method` means only methods, etc...

Multiple values can also be passed:
```
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
```

### Declare the Attribute class
The declaration of an attribute is similar to that of a regular class:
```
[AttributeUsage(AttributeTargets.Method)]
public class MyAttribute : Attribute
{
    // . . .
}
```

Attribute class rules:
- Must be public
- Convention is to end attribute class names with `Attribute`, inclusion of the word `Attribute` is optional when applied
- Must inherit directly or indirectly from `System.Attribute`
- Visual Basic (VB) requires custom attributes to have the `System.AttributeUsageAttribute` applied

### Constructors
Constructors are similar to normal traditional classes.

Declaring a property in the constructor makes that property mandatory when applying an attribute. Fields not specified in
the constructor are optional.

```
public class AuthorAttribute : System.Attribute
    {
        // fields
        private string name;
        public double version;

        // property
        public string Name { get => name; set => name = value; }

        // constructor
        public AuthorAttribute(string name)
        {
            Name = name;
            version = 1.0;
        }
    }
```

## Using reflection to get the value of an attribute
C# allows the use of reflection retrieve an attribute.

First, the wanted Attribute is retrieved using reflection where 't' is the class type with the want attribute applied:
```
AuthorAttribute AuthorAttribute = 
                (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));
```

Then it is as simple as checking if the attribute is `null` or not and returning the wanted value.

### Example
```
static string GetAuthorNameFromAnnotation(Type t)
        {
            AuthorAttribute AuthorAttribute = 
                (AuthorAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorAttribute));

            if (AuthorAttribute == null)
            {
                Console.WriteLine("Annotation not found.");
                return "";
            }
            else
            {
                return AuthorAttribute.Name;
            }
        }
```