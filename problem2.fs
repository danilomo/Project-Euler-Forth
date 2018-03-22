: ismultiple mod 0= ;

: reduce_if { func test }
	    BEGIN depth 3 >= WHILE
	      over test execute
	      IF func execute  ELSE swap drop then
	      REPEAT ;

: even? 2 ismultiple ;


: fib { n } 1 1 BEGIN dup n < WHILE  2dup + REPEAT drop ;


4000000 fib

0

' + ' even? reduce_if

.

10 emit 

bye
