# PolyGenetic Algorithm
*Implementation of a genetic algorithm, generic support for various domains, 
currently support for polygons (using their axial symmetry as a fitness function).*

## Main program components:
  - Genetic Algorithm
    - Adjust genetic algorithm parameters, choose different fitness function calculators, run genetic algorithm
  - Population Manager
    - Manage multiple polygons at once (automatic generation, saving, loading)
  - Shape Creator
    - Define polygon shapes, colors, names
    
## To create a new domain, the following needs to be implemented:
  - [ ] **IGene(s)**
  - [ ] **IIndividual(s)** using your implemented IGene
  - [ ] **GeneticAlgortihm Adapter** (**Crossover** method between your IIndividuals, all other methods are already implemented generically)
  - [ ] **Fitness Calculator(s)** evaluating your IIndividual's fitness
  - [ ] \(Optional: some sort of **feedback** on the progress of your domain's GAs)
