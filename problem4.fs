: create-stack
  dup
  1 + cells allocate throw dup 0 swap !
  over over swap cells erase
  swap drop
; 

: write-on-top ( address n -- address )  swap dup dup @ 1 + cells + rot swap ! ;

: move-cursor ( address n -- address ) over dup @ rot + swap ! ;

: push ( address n -- address )
  write-on-top
  1 move-cursor
;



: pop ( address -- n address )
  dup dup @ cells + @  swap -1 move-cursor  ;

: is-empty ( address -- address flag )
  dup @ 0= ;


: print-stack { addr }
  cr  
  addr @ 0 do
     i cells addr + 1 cells + ? cr
  loop
  addr
;

: func { stack n m }
  n m n m
  BEGIN
    > 
  WHILE
    2dup
    mod
    rot swap dup
    3 pick 10 / /
    stack swap push drop
    -
    swap 10 *
    2dup
  REPEAT
  10 / / stack swap push drop
  
;

: check-palindrome-aux { stack }
		   stack @ 2 / 0 do
		     stack i 1 + cells + @ 
		     stack stack @ i - cells + @

		     = 0= if stack false unloop exit then
		   loop
		   stack true
;


: check-palindrome { n } 100 create-stack dup n 10 func check-palindrome-aux swap free throw ;

: swap-and-drop-if-greater 2dup < if swap drop else drop then ; 

: largest-palindrome

  0
  
  1000 100 do
    1000 100 do
      i j *
      check-palindrome if
	i j *
	swap-and-drop-if-greater
      then      
    loop
  loop
;

largest-palindrome

.s cr bye
