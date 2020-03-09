#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <unistd.h>
#include "freertos/FreeRTOS.h"
#include "freertos/task.h"
#include "driver/gpio.h"
#include "sdkconfig.h"

// Define sensor pins under variable names.
#define S1 34
#define S2 35
#define S3 32
#define KL1 33
#define KL2 25
#define GRN 26
#define RED 27

clock_t tS = 0;				// Time variable for the start of the loop
clock_t t = 0; 				// Timestamp
clock_t tdif = 0;			// T1 - T2
clock_t t1 = 0;				// Time when Piezo 1 registers HIGH
clock_t t2 = 0;				// Time when Piezo 2 registers HIGH
long int tEnd = 2000;		// Wait time for the loop
int Sen1 = 0;		    	// Sensor 1 Level
int Sen2 = 0;				// Sensor 2 Level
int die = 1;				// Indicator for if the die has been rolled
int end = 0;				// Indicator for if the end of the 
							// run has been reached

int app_main(){
	// Assign variables to GPIO pins
    gpio_pad_select_gpio(S1);
    gpio_pad_select_gpio(S2);
    gpio_pad_select_gpio(S3);
    gpio_pad_select_gpio(KL1);
    gpio_pad_select_gpio(KL2);
    gpio_pad_select_gpio(GRN);
    gpio_pad_select_gpio(RED);
    
    // Set the GPIO as input pin
    // Piezos
    gpio_set_direction(S1, GPIO_MODE_INPUT);
    gpio_set_direction(S2, GPIO_MODE_INPUT);
    gpio_set_direction(S3, GPIO_MODE_INPUT);
    
    // LEDs
    gpio_set_direction(KL1, GPIO_MODE_OUTPUT);
    gpio_set_direction(KL2, GPIO_MODE_OUTPUT);
    gpio_set_direction(GRN, GPIO_MODE_OUTPUT);
    gpio_set_direction(RED, GPIO_MODE_OUTPUT);
    
    while(1) {
		if(die == 1){
			int r = rand() % 2;
			if(r == 1){
				gpio_set_level(KL1, 1);
			}
			else{
				gpio_set_level(KL2, 1);
			}
			die = 0;
			tS = clock();
		}
		// Timer
		t = clock();
		
		// Listen to the pins, and print if it's High or Low
		if(Sen1 == 0){
			Sen1 = gpio_get_level(S1);
		}
		
		if(Sen2 == 0){
			Sen2 = gpio_get_level(S2);
		}
		
		if(Sen1 == 1 && t1 == 0){ 
			t1 = t;
		}
		
		if(Sen2 == 1 && t2 == 0){ 
			t2 = t;
		}
		
		if(t1 != 0 && t2 != 0){
			tdif = t1 - t2;
		}
		
		if(KL1 == 1 && tdif > tS){
			gpio_set_level(GRN, 1);
		}
		else if(KL2 == 1 && tdif < tS){
			gpio_set_level(GRN, 1);
			end = 1;
		}

		if((end == 1 || (t1 == 0 && t2 == 0)) && t >= tS+2000){
			if((t1 == 0 && t2 == 0) || 
			   (t1 != 0 && t2 == 0) || (t1 == 0 && t2 !=0)){
				gpio_set_level(RED, 1);
			}
			
			// Wait 0.5 seconds
			// To make the game faster reduce this number. Microseconds
			usleep(500000);
			
			// Turn all LEDs off
			gpio_set_level(GRN, 0);
			gpio_set_level(RED, 0);
			gpio_set_level(KL2, 0);
			gpio_set_level(KL1, 0);
			
			// Reset variables for the next key
			t1 = 0;
			t2 = 0;
			die = 1;
			end = 0;
		}
    }
}
