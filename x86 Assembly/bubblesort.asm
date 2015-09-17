; James Shaver
; Bubble sort of an array of numbers in assembly.
; 7/22/2014

.486
.model flat, stdcall
option casemap :none

include \masm32\include\windows.inc
include \masm32\include\masm32.inc
include \masm32\include\kernel32.inc
include \masm32\macros\macros.asm

includelib \masm32\lib\masm32.lib
includelib \masm32\lib\kernel32.lib

.data

    temp        DD 0
    aa          DW 10 DUP(5, 7, 6, 1, 4, 3, 9, 2, 10, 8)

.code

start: 

    cls  ; clearing screen
    ;setting up counters
    
    mov ecx, 0
    mov edx, 0 
    
top:

    cmp edx, 10
    je  inc_loop
    inc edx             
    mov ax, [aa+ecx*2]  ; moves array index 0 into eax

    cmp [aa+edx*2], ax  ; compares index 1 to index 2
    jl top             ; jumps to top if index1 is less than or equal to index 2
    
    ; swaps the values edx and ecx are pointing to
    mov bx, [aa+edx*2]  
    mov [aa+ecx*2], bx
    mov [aa+edx*2], ax
    jmp top

inc_loop:
    mov edx, -1
    inc ecx
    cmp ecx, 10
    jl top


    ; Output to Screen
    sub esi, esi
    print chr$("Bubble Sorted Array Results: ", 13,10)
    print chr$("[ ")
    
    ; Looping through the array
out_top:

    mov ax, [aa+esi*2]
    mov temp, eax
    print str$(temp)
    print chr$(", ")
    inc esi
    cmp esi, 9
    jne out_top

    ; Formatting the last character
    mov ax, [aa+esi*2]
    mov temp, eax
    print str$(temp)
    print chr$(" ]", 13, 10)

    exit

END start