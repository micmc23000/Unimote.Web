#!/usr/bin/env python

import RPi.GPIO as GPIO
import time
import sys


output_pins = {
    'JETSON_XAVIER': 18,
    'JETSON_NANO': 33,
    'JETSON_NX': 33,
}
output_pin = output_pins.get(GPIO.model, None)
if output_pin is None:
    raise Exception('PWM not supported on this board')


def main():
    # Pin Setup:
    # Board pin-numbering scheme
    #signal= sys.argv[1]
    signal = "10010110"
    
    GPIO.setmode(GPIO.BOARD)
    # set pin as an output pin with optional initial state of HIGH
    GPIO.setup(output_pin, GPIO.OUT, initial=GPIO.HIGH)
    
    val = 100
    incr = 100
    #pin.start(val)
    
    print("PWM running. Press CTRL+C to exit.")
    try:
        for bit in signal:
                print(bit)
                if bit=="1":
                    print("zero Volts")
                    time.sleep(.01)
                    GPIO.output(33, 1)
                if bit=="0":
                    print("3 volts")
                    GPIO.output(33, 0)
                    time.sleep(.01)
    finally:
         GPIO.cleanup()

if __name__ == '__main__':
    main()
