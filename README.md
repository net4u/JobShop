# JobShop
Points of interest regading not working partial views:

1.) in _HeaderBanner.cshtml I want to render LatestJobs.cshtml and LatestCandidates.cshtml  (lines 6 and 17)

2.) in _Layout.cshtml I want to render JobSlider.cshtml and CandidatesSlider.cshtml (lines 235 and 236)

Notes: 
1.) In App_Data folder is the script for database behind the models

2.) Since all views directly scaffolded by Visual Studio works well (Jobs, Candidates) I fail to obtain partial views that allows me to render on Home Page view data from those models (Jobs and Candidates) in various scenarious: latest Jobs, latest Candidates, count number of all Jobs, respectively all Candidates, display on Google Map the latest (or filtered on criteria) Lobs or Candidates. I allways have some exception(s) related to model passed to dictionary.

3.) Also I am interested to understand how to make views for entering data in Master/Detail situations (e.g. Jobs and it's child entities JobSkills, JobRequirements) using a single submit (I mean at a wizard like form, add a new Job with a partial form add new JobSkills)
