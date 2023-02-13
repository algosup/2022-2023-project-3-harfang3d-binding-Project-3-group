import lang.fsharp 

def bind_std(gen):
    class FSharpConstCharPtrConverter(lang.fsharp.FSharpTypeConverterCommon):
        def __init__(self, type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
            super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
            self.fsharp_to_c_type = "string"
            self.fsharp_type = "string"
            
        def get_type_glue(self, gen, module_name):
            return ''

        def get_type_api(self, module_name):
            return ''

        def to_c_call(self, in_var, out_var_p, is_pointer=False):
            if is_pointer:
                out = f"{out_var_p.replace('&', '_')} := Marshal.StringToHGlobalAnsi(*{in_var})\n"
            else:
                out = f"{out_var_p.replace('&', '_')} := Marshal.StringToHGlobalAnsi({in_var})\n"
            return out

        def from_c_call(self, out_var, expr, ownership):
            return f"Marshal.PtrToStringAnsi({out_var})"

    gen.bind_type(FSharpConstCharPtrConverter("const char*"))

    class FSharpBasicTypeConverter(lang.fsharp.FSharpTypeConverterCommon):
        def __init__(self, type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
            super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
            self.fsharp_to_c_type = type
            self.fsharp_type = type
            
        def get_type_glue(self, gen, module_name):
            return ''

        def get_type_api(self, module_name):
            return ''

        def to_c_call(self, in_var, out_var_p, is_pointer=False):
            if is_pointer:
                out = f"{out_var_p.replace('&', '_')} := {in_var}\n"
            else:
                out = f"{out_var_p.replace('&', '_')} := {in_var}\n"
            return out

        def from_c_call(self, out_var, expr, ownership):
            return f"{out_var}"

    gen.bind_type(FSharpBasicTypeConverter("char", "char", "int8"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned char", "uchar", "uint8"))
    gen.bind_type(FSharpBasicTypeConverter("uint8_t", "uchar", "uint8"))
    gen.bind_type(FSharpBasicTypeConverter("short", "short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("int16_t", "short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("char16_t", "short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("uint16_t", "ushort", "uint16"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned short", "ushort ", "uint16"))
    gen.bind_type(FSharpBasicTypeConverter("int32", "int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("int", "int32_t", "int"))
    gen.bind_type(FSharpBasicTypeConverter("int32_t", "int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("char32_t", "int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("size_t", "size_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("uint32_t", "uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned int32_t", "uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned int", "uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("int64_t", "int64_t", "int64"))
    gen.bind_type(FSharpBasicTypeConverter("long", "int64_t", "int64"))
    gen.bind_type(FSharpBasicTypeConverter("float32", "float", "float32"))
    gen.bind_type(FSharpBasicTypeConverter("float", "float", "float32"))
    gen.bind_type(FSharpBasicTypeConverter("intptr_t", "intptr_t", "uintptr"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned long", "uint64_t", "uint64"))
    gen.bind_type(FSharpBasicTypeConverter("uint64_t", "uint64_t ", "uint64"))
    gen.bind_type(FSharpBasicTypeConverter("double", "double", "float64"))

    class FSharpBoolConverter(lang.fsharp.FSharpTypeConverterCommon):
        def __init__(self, type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
            super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
            self.fsharp_to_c_type = "bool"
            self.fsharp_type = "bool"
            
        def get_type_glue(self, gen, module_name):
            return ''

        def get_type_api(self, module_name):
            return ''

        def to_c_call(self, in_var, out_var_p, is_pointer=False):
            if is_pointer:
                out = f"{out_var_p.replace('&', '_')} := {in_var}\n"
            else:
                out = f"{out_var_p.replace('&', '_')} := {in_var}\n"
            return out

        def from_c_call(self, out_var, expr, ownership):
            return f"{out_var}"
    gen.bind_type(FSharpBoolConverter("bool", "bool", "bool")).nobind = True
