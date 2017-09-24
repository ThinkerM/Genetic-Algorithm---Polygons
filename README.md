# PolyGenetic Algorithm
*Implementation of a genetic algorithm, generic support for various domains, 
currently support for polygons (using their axial symmetry as a fitness function).*

## How to launch:
1. Download the latest release
2. Launch the setup and install
3. Launch the executable in the installed folder

## View documentation:
If you want to see a detailed class list with documented method signatures, you need to download the repository and launch one of the _.html_ files in the _Documentation_ folder.

## Main program components:
  - Genetic Algorithm
    - Adjust genetic algorithm parameters, choose between different fitness function calculators, run genetic algorithm
  - Population Manager
    - Manage multiple polygons at once (automatic generation, saving, loading)
  - Shape Creator
    - Define polygon shapes, colors, names
    
## To create a new domain, the following needs to be done:
  - [ ] Reference the "*Genetic_Algorithm*" library (```Genetic_Algorithm.GA.Generics```)
  ### Implement:
  - [ ] **IGene(s)**
  - [ ] **IIndividual(s)** using your implemented IGene
  - [ ] **GeneticAlgortihm Adapter** (**Crossover** method between your IIndividuals, all other methods are already implemented generically)
  - [ ] **Fitness Calculator(s)** evaluating your IIndividual's fitness
  - [ ] *(Optional: some sort of **feedback** on the progress of your domain's GAs)*
