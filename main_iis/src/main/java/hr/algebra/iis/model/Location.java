package hr.algebra.iis.model;

import com.fasterxml.jackson.annotation.JsonBackReference;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonManagedReference;
import com.google.gson.annotations.SerializedName;
import jakarta.persistence.*;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import java.io.Serializable;
import java.util.List;
import java.util.Set;

@XmlType(namespace = "http://www.w3.org/2001/location")
@Entity
@Table(name = "location")
public class Location implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    int id;

    String name;

    String type;

    String dimension;

    @OneToMany(mappedBy = "location")
    Set<Character> characters;

    @XmlAttribute
    public int getId() {
        return id;
    }

    @XmlElement(name = "name", required = false)
    public String getName() {
        return name;
    }

    @XmlElement(name = "type", required = false)
    public String getType() {
        return type;
    }

    @XmlElement(name = "dimension", required = false)
    public String getDimension() {
        return dimension;
    }

    @XmlTransient
    @JsonBackReference
    public Set<Character> getCharacters() {
        return characters;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setDimension(String dimension) {
        this.dimension = dimension;
    }

    public void setCharacters(Set<Character> characters) {
        this.characters = characters;
    }
}
