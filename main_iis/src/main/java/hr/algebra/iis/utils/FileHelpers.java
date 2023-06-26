package hr.algebra.iis.utils;

import java.io.File;
import java.util.Objects;


public class FileHelpers {
    public static File getFile(String location) {
        ClassLoader classLoader = FileHelpers.class.getClassLoader();
        return new File(Objects.requireNonNull(classLoader.getResource(location)).getFile());
    }
}
