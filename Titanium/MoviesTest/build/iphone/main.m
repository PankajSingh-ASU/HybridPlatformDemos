//
//  Appcelerator Titanium Mobile
//  WARNING: this is a generated file and should not be modified
//

#import <UIKit/UIKit.h>
#define _QUOTEME(x) #x
#define STRING(x) _QUOTEME(x)

NSString * const TI_APPLICATION_DEPLOYTYPE = @"development";
NSString * const TI_APPLICATION_ID = @"com.appcelerator.movies";
NSString * const TI_APPLICATION_PUBLISHER = @"Appcelerator";
NSString * const TI_APPLICATION_URL = @"http://www.appcelerator.com";
NSString * const TI_APPLICATION_NAME = @"Movies";
NSString * const TI_APPLICATION_VERSION = @"1.0.1";
NSString * const TI_APPLICATION_DESCRIPTION = @"Movies app";
NSString * const TI_APPLICATION_COPYRIGHT = @"2015 by Appcelerator";
NSString * const TI_APPLICATION_GUID = @"9d13582e-7362-4642-9aaa-1a8ede5d42a2";
BOOL const TI_APPLICATION_ANALYTICS = false;
NSString * const TI_APPLICATION_BUILD_TYPE = @"";

#ifdef TARGET_IPHONE_SIMULATOR
NSString * const TI_APPLICATION_RESOURCE_DIR = @"";
#endif

int main(int argc, char *argv[]) {
    NSAutoreleasePool * pool = [[NSAutoreleasePool alloc] init];

#ifdef __LOG__ID__
	NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
	NSString *documentsDirectory = [paths objectAtIndex:0];
	NSString *logPath = [documentsDirectory stringByAppendingPathComponent:[NSString stringWithFormat:@"%s.log",STRING(__LOG__ID__)]];
	freopen([logPath cStringUsingEncoding:NSUTF8StringEncoding],"w+",stderr);
	fprintf(stderr,"[INFO] Application started\n");
#endif

	int retVal = UIApplicationMain(argc, argv, nil, @"TiApp");
    [pool release];
    return retVal;
}
