# Demo.HelloWorld

Talk Notes:

Octopus 
	Continuous deployment vs continuous delivery
		Add OctoPack from NuGet
RunOctoPack
	Teamcity 1
		Create build configuration		
		Add project to agent pools
		Restore NuGet packages
Supply OctoPack package version in build step
Change build number format in General Settings
		Add package push step	
			Goto Octopus > Library > Packages and get the URL
Create Octopus Environments 
	Remote desktop to:  nick-demo-test, nick-demo-prod
	Create Environments in Octopus 
	Create Octopus Lifecycles
	Create Octopus project	
		Define steps	
	Teamcity 2
		Add release creation step
		Add test run step
		Add promotion step
	Break the implementation and push changes
