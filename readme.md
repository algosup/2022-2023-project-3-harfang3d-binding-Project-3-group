# Fabgen - The fabulous generator

Fabgen is a set of Python scripts to generate C++ binding code to different languages.  
It was written as a SWIG replacement for the Harfang Multimedia Framework (http://www.harfang3d.com).

## Author

Fabgen is written and maintained by Emmanuel Julien for the Harfang Multimedia Framework (http://www.harfang3d.com).

## License

Fabgen is licensed under the GPLv3.

## Goals

1. Support multiple target language.
1. Bidirectional binding. Bind C++ functions to target language and target language functions to C++.
1. Provide an API for embedding (runtime C type name to target name query, human-readable type conversion functions, etc...).
1. Full feature support for all target language unless technicaly impossible in which case a sensible fallback should be provided.
1. Provide fast binding

## Philosophy

1. Keep as much code as possible on the generic part of the generator (gen.py).
1. Any feature that can be done using what's available should be culled (aka. no feature creep).
1. Output library must feel as native as possible to the target language.

## Features

- Generated code has no dependencies and is human readable.
- Generator input is a Python script.
- Customizable type conversion from C/C++ and back.
- Can bind many C/C++ construct.
- User specifiable bound name.
- Types can be hidden from the generated binding interface.
- Feature mechanism to extend types and prototypes such as:
  - `arg_out`, `arg_in_out` to support output arguments.
  - `route` to route methods to a customizable expression.
  - `proxy` to support wrapper types such as std::shared_ptr<T>.
- Simple and hopefully easy to dive into codebase.

## Supported target language

- CPython 3.2+ using the CPython limited API (`Py_Limited_API`) (generated modules can be used on all CPython version >=3.2)
- Lua 5.2+

## Contributions

Contributions are welcome. Please submit merge requests with working unit test to the project Github directly.

## Basic usage

TODO

## Extending through feature

Type converters and function prototypes all accept a list or dictionary of features when declared.

### Extending type converter with feature

- 'proxy': class ProxyFeature

Types using this feature are declared as wrapper for another underlying type.
This feature is used to unwrap arguments to a call and wrap its return value.

Note: A type converter proxy feature is consumed by prototypes proxy feature, see the prototype feature documentation.

Support for std::shared_ptr is done with the proxy feature.

```python
class StdSharedPtrProxyFeature:
    def __init__(self, wrapped_conv):
        self.wrapped_conv = wrapped_conv

    def init_type_converter(self, gen, conv):
        # declare shared_ptr<T> to T cast support
        gen.add_cast(conv, self.wrapped_conv, lambda in_var, out_var: '%s = ((%s *)%s)->get();\n' % (out_var, conv.ctype, in_var))

    def unwrap(self, in_var, out_var):
        return '%s = %s->get();\n' % (out_var, in_var)

    def wrap(self, in_var, out_var):
        return '%s = new std::shared_ptr<%s>(%s);\n' % (out_var, self.wrapped_conv.ctype, in_var)
```

- 'sequence': Class

Provide native access for the target language to values stored in a container type.

### Extending function prototype with feature

- 'route': def router(var, args)

This feature redirects an object method (static or not) to a function with a compatible signature.
It can be used to extend classes with additional methods while not modifying the existing C++ class.

- 'arg_out': []

Dictionary of argument names to consider as output to the bound function.
Output arguments do not take part in overload resolution and are not provided by the function caller.

Output arguments are appended to the function return value.

- 'arg_in_out': []

Dictionary of argument names to consider as input-output to the bound function.
Input-output arguments take part in overload resolution and are provided by the function caller.

Input-output arguments are appended to the function return value.

- 'proxy': None

Route a method call to the type wrapped by the 'proxy' feature of the converter used of the declaration.
This feature does not provide any value.
This feature can be used to wrap constructors.

```python
# With shared_ptr_to_obj_conv being a TypeConverter with a proxy feature,
# call the PrintState method through the shared pointer.
gen.bind_method(shared_ptr_to_obj_conv, 'PrintState', 'void', [], features=['proxy'])
```

- 'new_obj': None

By default, values returned by reference or pointer are assumed C++ ownership.
This feature transfers the returned object ownership to the target language.

- 'check_rval': def check(rvals):

Insert return value checking code right after the native call.

## Performance notes

### Beware of silent conversions when providing advanced interoperability with a target language

Consider the following example scenario when binding `std::vector<int>` to CPython:

1. The bound type will implement the Sequence protocol (if you use the standard StdVector type converter which implements this feature).
1. We define a function with two equivalent prototypes taking one argument. One accepts `std::vector<int>`, the other one a PySequence of int as a convenience to the user.
1. If the PySequence prototype is listed first CPython will accept `std::vector<int>` as PySequence during dynamic dispatch since it implements the Sequence protocol.

This can have serious performance implications as the PySequence always need to be extracted to a temporary `std::vector<int>` before the native call is made.  
A wrapped `std::vector<int>` object does not undergo any transformation and is passed right away to the native layer.
