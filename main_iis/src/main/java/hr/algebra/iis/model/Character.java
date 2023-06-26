package hr.algebra.iis.model;


import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;

import javax.xml.bind.annotation.*;
import java.io.Serializable;
import java.util.List;
import java.util.Set;

@XmlType(namespace = "http://www.w3.org/2001/character")
@XmlRootElement(name = "character")
@Entity
@Table(name = "character")
public class Character implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id ;

    String name;

    @Enumerated(EnumType.ORDINAL)
    Status status;

    String species;

    String type;

    @Enumerated(EnumType.ORDINAL)
    Gender gender;

    @OneToOne(cascade = CascadeType.MERGE)
    Location origin;

    @ManyToOne(cascade = CascadeType.MERGE)
    @JoinColumn(name = "location_id", nullable = false)
    Location location;

    String image;

    @ManyToMany(cascade = CascadeType.MERGE)
    @JoinTable(
            name = "character_episode",
            joinColumns = @JoinColumn(name = "character_id"),
            inverseJoinColumns = @JoinColumn(name = "episode_id")
    )
    List<Episode> episodes;

    @XmlAttribute
    public int getId() {
        return id;
    }

    @XmlElement(name = "name")
    public String getName() {
        return name;
    }

    @XmlElement(name = "status")
    public Status getStatus() {
        return status;
    }

    @XmlElement(name = "species")
    public String getSpecies() {
        return species;
    }

    @XmlElement(name = "type")
    public String getType() {
        return type;
    }

    @XmlElement(name = "gender")
    public Gender getGender() {
        return gender;
    }

    @XmlElement(name = "origin")
    @JsonManagedReference
    public Location getOrigin() {
        return origin;
    }

    @XmlElement(name = "location")
    @JsonManagedReference
    public Location getLocation() {
        return location;
    }

    @XmlElement(name = "image")
    public String getImage() {
        return image;
    }

    @XmlElementWrapper(name = "episodes")
    @XmlElement(name = "episode")
    @JsonManagedReference
    public List<Episode> getEpisodes() {
        return episodes;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setStatus(Status status) {
        this.status = status;
    }

    public void setSpecies(String species) {
        this.species = species;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setGender(Gender gender) {
        this.gender = gender;
    }

    public void setOrigin(Location origin) {
        this.origin = origin;
    }

    public void setLocation(Location location) {
        this.location = location;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public void setEpisodes(List<Episode> episodes) {
        this.episodes = episodes;
    }

    public enum Gender {

        UNKNOWN,

        FEMALE,

        MALE,

        GENDERLESS
    }

    public enum Status {

        UNKNOWN,

        ALIVE,

        DEAD
    }
}
