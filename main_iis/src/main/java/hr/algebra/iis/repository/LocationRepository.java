package hr.algebra.iis.repository;

import hr.algebra.iis.model.Location;
import org.springframework.data.jpa.repository.JpaRepository;

public interface LocationRepository extends JpaRepository<Location, Integer> {
    boolean existsByNameAndTypeAndDimension(String name, String type, String dimension);
    Location getByNameAndTypeAndDimension(String name, String type, String dimension);
}
