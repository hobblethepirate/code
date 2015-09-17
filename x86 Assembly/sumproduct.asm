; James Shaver
; Sum and Product of three unsigned 8 bits numbers.

.486
.model flat, stdcall
option casemap :none

include \masm32\include\windows.inc
include \masm32\include\masm32.inc
include \masm32\include\kernel32.inc
include \masm32\macros\macros.asm

includelib \masm32\lib\masm32.lib
includelib \masm32\lib\kernel32.lib

.DATA

    sum1        DD 0
    sum2        DD 0

    product1    DW 0
    product2    DD 0
    
    var1        DB 0
    var2        DB 0 
    
.code

start: 

    cls
    print   chr$("Sum and Product of three unsigned 8 bit numbers. ")
    print   chr$(13,10,13,10)    
    mov     ebx, sval(input("Please enter a number (0-255): "))

    ; Filter input to 8 bits
    mov     eax, sval(input("Please enter another number (0-255): "))
    mov     ecx, 255
    and     eax, ecx
    and     ebx, ecx
    
    mov     var1, al        ; backing up al into var1
    
    adc     al, bl
    jnc     continue

    ; Carry has been set 
    mov     edx, 256        ; setting ebx to 256
    add     eax, edx        ; incrementing eax by 256
    
continue:

    mov     sum1, eax
    mov     al, var1
    mul     bl  
    mov     product1, ax    ; backing up ax, into product1
    mov     eax, 0          ; zero-ing out eax
    
    ; Getting third number
    
    mov     eax, sval(input("Please enter another number (0-255): "))

    ; Filter input to 8 bits
    mov     ecx, 255
    and     eax, ecx

    ; Multiplying and adding 3rd number to the equation
    mov     var2, al
    mov     ebx, 0          ; zero-ing out ebx
    mov     ebx, sum1
    adc     eax, ebx     
    mov     sum2, eax       ; zero-ing out eax
    mov     eax, 0
    mov     al, var2
    mov     ebx, 0          ; zero-ing out ebx
    mov     bx, product1
    mul     bx
    
    ; Combine dx:ax 
    
    shl     edx, 16         ; Shifting edx by 16 bits to the left
    add     eax, edx        ; adding eax and edx together to get the result
    mov     product2, eax

    ; Output to Screen

    print chr$(13, 10)
    
    print chr$("Sum: ")
    print str$(sum2)
    print chr$(13, 10)
    
    print chr$("Product: ")
    print str$(product2)
    print chr$(13, 10) 
    
    exit

END start