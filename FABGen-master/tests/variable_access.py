import lib


def bind_test(gen):
	gen.start('my_test')

	lib.bind_defaults(gen)

	# inject test code in the wrapper
	gen.insert_code('''\
int v{2};

struct simple_struct {
	int v{4};
};

simple_struct s;

namespace ns {
	int v{14};
	float u{7.f};
}
''', True, False)

	simple_struct = gen.begin_class('simple_struct')
	gen.bind_member(simple_struct, 'int v')
	gen.end_class(simple_struct)

	gen.bind_variables(['int v', 'simple_struct s'])
	gen.bind_variable('int ns::v', bound_name='w')

	gen.bind_variable('float ns::u')

	gen.finalize()
	return gen.get_output()


test_python = '''\
import my_test

assert my_test.v == 2
my_test.v = 5
assert my_test.v == 5

assert my_test.s.v == 4
my_test.s.v = 9
assert my_test.s.v == 9

assert my_test.w == 14

assert my_test.u == 7
'''

test_lua = '''\
my_test = require "my_test"

assert(my_test.v == 2)
my_test.v = 5
assert(my_test.v == 5)

assert(my_test.s.v == 4)
my_test.s.v = 9
assert(my_test.s.v == 9)

assert(my_test.w == 14)

assert(my_test.u == 7)
'''

test_go = '''\
package mytest

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

// Test ...
func Test(t *testing.T) {
	assert.Equal(t, GetV(), int32(2), "should be the same.")
	SetV(int32(5))
	assert.Equal(t, GetV(), int32(5), "should be the same.")

	assert.Equal(t, GetS().GetV(), int32(4), "should be the same.")
	GetS().SetV(int32(9))
	assert.Equal(t, GetS().GetV(), int32(9), "should be the same.")

	assert.Equal(t, GetW(), int32(14), "should be the same.")

	assert.Equal(t, GetU(), float32(7), "should be the same.")
}
'''

test_fsharp = '''\
namespace myTest
open System
open NUnit.Framework
open program

[<Test>]
let ``test`` () =
	Assert.AreEqual(2, v), "should be the same.")
	v <- 5
	Assert.AreEqual(5, v), "should be the same.")
	
	Assert.AreEqual(4, s.v), "should be the same.")
	s.v <- 9
	Assert.AreEqual(9, s.v), "should be the same.")

	Assert.AreEqual(14, w), "should be the same.")

	Assert.AreEqual(7, u), "should be the same.")
'''
