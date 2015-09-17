; James Shaver
; BubbleSort with an array of dates
; 8/1/2014


include \masm32\include\masm32rt.inc

.data?
number dd ?
.data

dates BYTE "23-JUL-2010", 0, "22-JUL-2010", 0, "23-JUL-2009", 0, "31-JUL-2012", 0, "05-MAR-2010", 0, "12-MAR-1010", 0
values dd 5 DUP(0, 0, 0, 0, 0)
nDates DWORD 6
counter DD 0
temp dd 0
years dd 0
months BYTE "JAN FEB MAR APR MAY JUN JUL AUG SEP OCT NOV DEC",0

.code

DateToNumber MACRO items, mons, result
    LOCAL loop_top
    PUSHAD
    
    lea EDI, [items]
    MOV AL, [EDI]
    AAA
    MOV BL, 10
    MUL BL
    MOV DL, AL
    ADD EDI, 1
    SUB EAX, EAX
    MOV AL, [EDI]
    AAA
    ADD DL, AL
    MOV result, EDX
    SUB EDX, EDX
    SUB ESI, ESI
    SUB EDI, EDI
    mov EAX, 0          ; EAX is the month number
 
    loop_top:
         lea ESI, [items+3] ; ESI will be a ptr into the date string we are trying to convert to a number
         lea EDI, [mons + EAX * 4]   ; EDI will be a ptr into the months array
 
         inc EAX
         mov ECX, 3          ; length of a month string
         cld
         repe cmpsb          ; compare mystring and months for 3 characters
 
         jne loop_top        ; keep looping until we find the month

    mov EBX, result
    mov BH,AL
    SUB EBX, EBX
    MOV years, EBX    
    lea EDI, [items]
    ADD EDI,7
    MOV AL, [EDI]
    AAA
    MOV BX, 1000
    MUL BX
    MOV years, EAX
    SUB BX, BX
    SUB EAX, EAX
    ADD EDI, 1
    MOV AL, [EDI]
    AAA
    MOV BX, 100
    MUL BX
    SUB BX, BX
    ADD years, EAX
    SUB EAX, EAX
    ADD EDI, 1
    MOV AL, [EDI]
    AAA
    MOV BX, 10
    MUL BX
    SUB BX, BX
    ADD years, EAX
    SUB EAX, EAX
    ADD EDI, 1
    MOV AL, [EDI]
    AAA
    SHL EAX, 16
    ADD result, EAX
    POPAD
ENDM




start: 
    MOV ECX, 1 
    SUB EDX, EDX
    SUB EAX, EAX  
    DateToNumber dates, months, number
    MOV EAX, number
    MOV values, EAX
    DateToNumber [dates+12], months, number
    MOV EAX, number

    MOV [values+4], EAX
    DateToNumber [dates+24], months, number
    MOV EAX, number
    MOV [values+8], EAX
    DateToNumber [dates+48], months, number
    MOV EAX, number
    MOV [values+16], EAX 
    DateToNumber [dates+36], months, number
    MOV EAX, number
    MOV [values+12], EAX
    DateToNumber [dates+60], months, number
    MOV EAX, number
    MOV [values+20], EAX
    print chr$("[ ",)

    ;lea EDI, [values]
    ;push EDI
    ;Call BubbleSort

    ;Call NumberToDate
 out_top:
    
    mov eax, [values+esi*4]
    mov temp, eax
    print str$(temp)
    print chr$(", ")
    inc esi
    cmp esi, 5
    jne out_top

    ; Formatting the last character
    mov eax, [values+esi*4]
    mov temp, eax
    print str$(temp)
    print chr$(" ]", 13, 10)
exit

;NumberToDate-
;   Parameter is a 32-bit unsigned number.
;   Turns the number back into its corresponding date string.
;   Returns the address of the string.
;
NumberToDate :

    enter 0, 0
    
    print "NumberToDate called"
    leave
    ret 0 

;BubbleSort-
;   Parameters are the address of an array of 32-bit unsigned numbers and the length of the array.
;   Sorts the array in place from smallest to largest.
;   No return value.
;
BubbleSort:

    enter 0, 0
    PUSHAD
    mov ecx, 0
    mov edx, 0 
    print "BubbleSort called"
  
    MOV ESI, [EBP + 8]
    
    top:
        cmp edx, 5
        je  inc_loop
        inc edx             
        mov eax, [esi+ecx*4]  ; moves array index 0 into eax

        cmp [esi+edx*4], eax  ; compares index 1 to index 2
        jl top             ; jumps to top if index1 is less than or equal to index 2
        
        ; swaps the values edx and ecx are pointing to
        mov ebx, [esi+edx*4]  
        mov [esi+ecx*4], ebx
        mov [esi+edx*4], eax
        jmp top

    inc_loop:
        mov edx, -1
        inc ecx
        cmp ecx, 5
        jl top
        
    POPAD
    leave
    ret 4    

END start

