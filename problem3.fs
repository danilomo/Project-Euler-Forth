: sqrt-closer ( square guess -- square guess adjustment) 2dup / over - 2 / ;  
: sqrt ( square -- root ) 1 begin sqrt-closer dup while + repeat drop nip ;  

variable i_

: prime { n }
	n 1 = if 0 exit then	
	n 3 <= if -1 exit then	
	n 2 mod 0= n 3 mod 0= or if 0 exit then	
	5 i_ !
	
	BEGIN  i_ @ i_ @ * n <= WHILE
		n i_ @ mod 0=
		n i_ @ 2 + mod 0=
		or if 0 exit then
		i_ @ 6 + i_ !
	REPEAT
	
	-1 ;

: factor { n }
	n sqrt 1 do
		n i mod
		0= if
			i prime if
				i
			then
		then	
	loop ;

\ 13195 factor

600851475143 factor


.s

10 emit

bye
		