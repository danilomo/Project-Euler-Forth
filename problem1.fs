: ismultiple mod 0= ;

: ismultiple5or3 dup 5 ismultiple swap 3 ismultiple or ;

: reduce_stack { func }  BEGIN depth 2 >= WHILE func execute REPEAT ;

: sequence_generator { test begin_ end_ }
		     end_ begin_ do i test execute if i then loop ;

' ismultiple5or3 1 1000 sequence_generator

' + reduce_stack

.

10 emit 

bye
