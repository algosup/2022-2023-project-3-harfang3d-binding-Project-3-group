from lib.std import StdSharedPtrProxyProtocol


def bind_test(gen):
	gen.start('my_test')

	# inject test code in the wrapper
	gen.insert_code('''\
struct simple_struct {
	float u = 4.f;
	int v = 7;
};

std::shared_ptr<simple_struct> get_shared_ptr_to_simple_struct() { return std::make_shared<simple_struct>(); }
''', True, False)

	gen.add_include('memory', True)

	simple_struct_conv = gen.begin_class('simple_struct')
	gen.bind_members('simple_struct', ['float u', 'int v'])
	gen.end_class('simple_struct')

	gen.begin_class('std::shared_ptr<simple_struct>', bound_name='ssimple_struct', proxy_protocol=StdSharedPtrProxyProtocol(simple_struct_conv))
	gen.bind_members('std::shared_ptr<simple_struct>', ['float u', 'int v'], enable_proxy_protocol=True)
	gen.end_class('std::shared_ptr<simple_struct>')

	gen.bind_function('get_shared_ptr_to_simple_struct', 'std::shared_ptr<simple_struct>', [])

	gen.finalize()
	return gen.get_output()


test_python = '''\
import my_test

from tests_api import expect_eq

sp = my_test.get_shared_ptr_to_simple_struct()

expect_eq(sp.u, 4.0)
expect_eq(sp.v, 7)
'''
