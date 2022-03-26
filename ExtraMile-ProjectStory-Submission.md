# Extra Mile
Team members: Michael Chen, Andreas Greiler-Basaldua, Tim Miller, Paris Nikitidis
### Elevator pitch
Extra Mile pairs brain wave data and AR to generate a virtual running companion that motivates users while exercising. Through gamification and competition, Extra Mile makes fitness more fun for all.
### Inspiration
A number of members on our team are very interested in the application of technology in the health and fitness space. Specifically, we were motivated by a statistic that shows 65% of people give up on their workout plans within 3 to 6 months, in part due to a lack of sustained enjoyment during physical exercise and the delayed gratification. We strongly believe that technology - if leveraged correctly - can make exercise more fun, encourage people to be more active, and ultimately help them lead healthier lives.

Over the past year, we have seen numerous health and fitness applications built for virtual reality (specifically for Oculus). Our team was inspired to build something using augmented reality because we want to encourage people to get out of their house and explore the awesome world around us. 

On the technology side, our team was inspired to take advantage of the awesome opportunity to hack on some really cool devices available to us at the hackathon.
- **Paris** came to the hackathon to experiment with new AR technology. He was keen to take advantage of his Unity experience to build something for Magic Leap 1. 
- **Tim** was very interested in understanding more about how the data collection and transformation process worked for the Muse headband and Neous App (developed by Arctop). He has seen so many fitness trackers out there that measure physical data, but none that capture brain wave data. He was particularly inspired to explore the possibilities of the brain wave data and how it could be used in the future to improve athlete performance.
- **Michael** was interested in hacking the Neous App and building on some of his Android app development skills. He was inspired to solve the difficult problem of connecting the Android App with *both* the Neuos App and Unity app to enable a livestream of brain wave data into the AR heads-up display
- **Andreas** was inspired to learn more about the backend technical details that go into building applications. He was most inspired to learn from Michael and Paris about the specific steps they took to build their apps.

### How we built it
Please see [HERE](https://github.com/agb721/extra_mile_playground/blob/main/images/setup.png) for a diagram on how we built the application.

To build our application we used a Magic Leap 1 and a Muse headband paired with the Neous App.

Below is an accompanying description on what the linked diagram shows:

- User puts on AR headset and brain wave headband. They set target pace for running companion and begin to run.
- AR device begins capturing pace, distance traveled, and time elapsed. This information is continuously collected over the session and streamed directly to the heads up display.
- The AR device also projects the running companion on the heads up display to help set the pace.
- The headband starts collecting brain wave data. The raw data is sent to the Neuos App. It is cleaned and transformed and then sends Flow, Enjoyment, Focus, and Heart Rate data to our custom Android app.
- The Android app then sends the data to a web server so that it can be accessed by Unity.
- Our Unity app pulls in the brainwave data and determines whether or not to adjust the running companion. If the Flow, Focus, and Enjoyment are low, the app may slow down the running companion. Or the app may increase music BPMs to motivate the user. If the Flow, Focus, and Enjoyment are high the app may increase the pace to help the user get the most out of the workout.

### What we learned
Even though the team was just together for two and a half days it is incredible to see all we learned. Here are some highlights:
- Tested out Magic Leap for the first time and got a much better understanding of its capabilities
- Worked with spatial mapping in Magic Leap and learned how to add dimensional elements to enable dynamic AR experiences.
- Learned more about numerous companies building both hardware and software products for the XR space. There is so much out there and so much potential
- Our team was multidisciplinary, so we had a great experience working across different expertises to build together most efficiently
- Working with the Neuos App forced us to learn how to make an Android app with Java.
- The hackathon was a great way to learn more about developing a MVP that balances limited time with wanting to show the full capabilities of our idea. We were constantly prioritizing features and ideas to make sure we stayed within the time limit.
- The less technical team members got some great exposure to new development tools and development environments including Github, Unity, Android Studio, Firebase, and Java.
- We also learned the importance of anticipating compatibility across platforms. Not all technologies are compatible which often throws off the best laid plans. We constantly had to reevaluate our idea and figure out small workarounds to get to the outcome we wanted.

### Challenges we faced
- Augmented reality
  - AR is still not up to handling real-time rendering in totally new environments. Ideally a user can put on the headset and the running companion can take them anywhere. But that is not very possible right now. To work around this, we had to first map out a very specific area. In that area we mapped a virtual track for the companion to follow. The user could then follow the companion around that pre-set track.
  - Additionally, there are still some field of vision issues with AR devices. This made it difficult to “find” the running companion sometimes as we started the application.
  - There were also some lag issues with the live data display that we set up. When we moved our head the data display did not follow as fast as needed, making it tough for the user to get maximum value out of the app.
- Neuos App
  - The Neuos App is only available on Android, so there was troubling finding a device at the hackathon to test on.
  - We spent a significant amount of time building a connection between the Neous App and our Android app.
  - Furthermore, there was no direct connection between Neuos and Unity. Therefore, we had to leverage Firebase as an intermediary to allow a real time connection.
- Other
  - The most obvious challenge is that AR devices are still not ideal for running.They are still bulky and heavy. As devices shrink over time, there is lots of potential for AR fitness applications.
  - The Muse headband had some difficulty registering data when we were moving around too much. This was not ideal for tracking data while running.

##
##
*THANK YOU TO THE ORGANIZERS, MENTORS, AND SPONSORS FOR AN AWESOME EVENT. WE LEARNED SO MUCH, MET SO MANY GREAT PEOPLE, AND HAD AN AWESOME TIME.*
