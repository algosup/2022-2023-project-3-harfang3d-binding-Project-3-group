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

    gen.bind_type("const char*", FSharpConstCharPtrConverter)

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

    gen.bind_type(FSharpBasicTypeConverter("char", "C.char", "int8"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned char", "C.uchar", "uint8"))
    gen.bind_type(FSharpBasicTypeConverter("uint8_t", "C.uchar", "uint8"))
    gen.bind_type(FSharpBasicTypeConverter("short", "C.short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("int16_t", "C.short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("char16_t", "C.short", "int16"))
    gen.bind_type(FSharpBasicTypeConverter("uint16_t", "C.ushort", "uint16"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned short", "C.ushort ", "uint16"))
    gen.bind_type(FSharpBasicTypeConverter("int32", "C.int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("int", "C.int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("int32_t", "C.int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("char32_t", "C.int32_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("size_t", "C.size_t", "int32"))
    gen.bind_type(FSharpBasicTypeConverter("uint32_t", "C.uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned int32_t", "C.uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned int", "C.uint32_t", "uint32"))
    gen.bind_type(FSharpBasicTypeConverter("int64_t", "C.int64_t", "int64"))
    gen.bind_type(FSharpBasicTypeConverter("long", "C.int64_t", "int64"))
    gen.bind_type(FSharpBasicTypeConverter("float32", "C.float", "float32"))
    gen.bind_type(FSharpBasicTypeConverter("float", "C.float", "float32"))
    gen.bind_type(FSharpBasicTypeConverter("intptr_t", "C.intptr_t", "uintptr"))
    gen.bind_type(FSharpBasicTypeConverter("unsigned long", "C.uint64_t", "uint64"))
    gen.bind_type(FSharpBasicTypeConverter("uint64_t", "C.uint64_t ", "uint64"))
    gen.bind_type(FSharpBasicTypeConverter("double", "C.double", "float64"))

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
    gen.bind_type(FSharpBoolConverter("bool", "C.bool", "bool")).nobind = True
